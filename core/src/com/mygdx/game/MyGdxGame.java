package com.mygdx.game;

import com.badlogic.gdx.ApplicationAdapter;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.math.Vector2;
import com.mygdx.game.sprites.Player;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Iterator;
import io.socket.client.IO;
import io.socket.client.Socket;
import io.socket.emitter.Emitter;

public class MyGdxGame extends ApplicationAdapter {
	private final float UPDATE_TIME = 1/60f;
	float timer;
	SpriteBatch batch;
	private Socket socket;
	Player player;
	Texture player1;
	Texture player2;
	HashMap<String, Player> friendlyPlayers;

	@Override
	public void create () {
		batch = new SpriteBatch();
		player1 = new Texture("playership2.png");
		player2 = new Texture("playership.png");
		friendlyPlayers = new HashMap<String, Player>();
		connectSocket();
		configSocketEvents();
	}

	@Override
	public void render () {
		Gdx.gl.glClearColor(0, 0, 0, 1);
		Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
		handleInput(Gdx.graphics.getDeltaTime());
		updateServer(Gdx.graphics.getDeltaTime());
		batch.begin();
		if(player != null) {
			player.draw(batch);
		}
		for(HashMap.Entry<String, Player> entry : friendlyPlayers.entrySet()) {
			entry.getValue().draw(batch);
		}
		batch.end();
	}

	public void handleInput(float delta) {
		if(player!= null) {
			if(Gdx.input.isKeyPressed(Input.Keys.LEFT)) {
				player.setPosition(player.getX() -200 * delta, player.getY());
			} else if(Gdx.input.isKeyPressed(Input.Keys.RIGHT)) {
				player.setPosition(player.getX() + 200 * delta, player.getY());
			}
		}
	}

	public void connectSocket() {
		try {
			socket = IO.socket("http://localhost:8080");
			socket.connect();
		} catch(Exception e) {
			Gdx.app.log("SocketIO", "Connection Error: " + e);
		}
	}

	public void configSocketEvents() {
		socket.on(Socket.EVENT_CONNECT, new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				Gdx.app.log("SocketIO", "Connected");
				player = new Player(player1);
			}
		}).on("socketID", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONObject data = (JSONObject) args[0];
				try {
					String id = data.getString("id");
					Gdx.app.log("SocketIO", "My ID: " + id);
				} catch(JSONException e) {
					Gdx.app.log("SocketIO", "Error getting ID");
				}
			}
		}).on("newPlayer", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONObject data = (JSONObject) args[0];
				try {
					String playerID = data.getString("id");
					Gdx.app.log("SocketIO", "New Player Connected: " + playerID);
					friendlyPlayers.put(playerID, new Player(player2));
				} catch(JSONException e) {
					Gdx.app.log("SocketIO", "Error getting new player ID");
				}
			}
		}).on("playerDisconnected", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONObject data = (JSONObject) args[0];
				try {
					String id = data.getString("id");
					friendlyPlayers.remove(id);
				} catch(JSONException e) {
					Gdx.app.log("SocketIO", "Error getting new player ID");
				}
			}
		}).on("getPlayers", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONArray objects = (JSONArray) args[0];
				try {
					for(int i = 0; i < objects.length(); i++) {
						Player coopPlayer = new Player(player2);
						Vector2 pos = new Vector2();
						pos.x = ((Double) objects.getJSONObject(i).getDouble("x")).floatValue();
						pos.y = ((Double) objects.getJSONObject(i).getDouble("y")).floatValue();
						coopPlayer.setPosition(pos.x, pos.y);

						friendlyPlayers.put(objects.getJSONObject(i).getString("id"), coopPlayer);
					}
				} catch(JSONException e) {
				}
			}
		}).on("playerMoved", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONObject data = (JSONObject) args[0];
				try {
					String playerID = data.getString("id");
					Double x = data.getDouble("x");
					Double y = data.getDouble("y");
					if(friendlyPlayers.get(playerID) != null) {
						friendlyPlayers.get(playerID).setPosition(x.floatValue(), y.floatValue());
					}
				} catch(JSONException e) {
				}
			}
		});
	}

	public void updateServer(float delta) {
		timer += delta;
		if(timer >= UPDATE_TIME && player != null && player.hasMoved()) {
			JSONObject data = new JSONObject();
			try{
				data.put("x", player.getX());
				data.put("y", player.getY());
				socket.emit("playerMoved", data);
			} catch(JSONException e) {
				Gdx.app.log("SocketIO", "Error sending update data");
			}
		}
	}

	@Override
	public void dispose () {
		super.dispose();
		batch.dispose();
		player1.dispose();
		player2.dispose();
	}
}
