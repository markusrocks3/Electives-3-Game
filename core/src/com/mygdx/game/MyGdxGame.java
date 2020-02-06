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
	SpriteBatch batch;
	private Socket socket;
	String id;
	Player player;
	Texture player1;
	Texture player2;
HashMap<String, Player> friendlyPlayers;

	@Override
	public void create () {
		batch = new SpriteBatch();
		player1 = new Texture("playerShip.png");
		player2 = new Texture( "playerShip2.png");
		friendlyPlayers = new HashMap<String, Player>();

        connectSocket();
		configSocketEvents();
	}
public  void handleInput(float dt){
	    if(player != null) {
	        if(Gdx.input.isKeyPressed(Input.Keys.LEFT)) {
    player.setPosition(player.getX() + (-200 * dt), player.getY());
            }else if (Gdx.input.isKeyPressed(Input.Keys.RIGHT)) {
                player.setPosition(player.getX() + (200 * dt), player.getY());
        }
}
}
	@Override
	public void render (){
		Gdx.gl.glClearColor(1, 0, 0, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);
		handleInput(Gdx.graphics.getDeltaTime());

		batch.begin();
		if ( player !=null){
		    player.draw(batch);
        }
		for (HashMap.Entry<String, Player>entry : friendlyPlayers.entrySet()){
		    entry.getValue().draw(batch);
        }
		batch.end();
	}

    @Override
    public void dispose() {
        super.dispose();
        player1.dispose();
        player2.dispose();
    }

    public void connectSocket() {
		try {
			socket = IO.socket("http://localhost:8080");
			socket.connect();
		} catch (Exception e) {
			System.out.println(e);
		}
	}
public void configSocketEvents(){

		socket.on(Socket.EVENT_CONNECT, new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				Gdx.app.log("SocketIO", "Connected");
				player = new Player(player1);
			}
		}).on("socketID", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONObject data = (JSONObject)args[0];
			try{	String id = data.getString("id");
Gdx.app.log("SocketIO", "My ID: " + id);

			}catch(JSONException e){
				Gdx.app.log("SocketIO","Error getting ID");
			}
			}
		}).on("newPlayer", new Emitter.Listener() {
			@Override
			public void call(Object... args) {
				JSONObject data = (JSONObject)args[0];
				try{	String id = data.getString("id");
					Gdx.app.log("SocketIO", "New Player Connected: " + id);
friendlyPlayers.put(id, new Player(player2));
				}catch(JSONException e){
					Gdx.app.log("SocketIO","Error getting New Player ID");
				}
			}

		});

	}


}
