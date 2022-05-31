![seamlogo](https://user-images.githubusercontent.com/92270179/171294801-928f97ea-0a46-44bc-9d33-23662bb6741a.png)

# SeaMasters-Battleship
Your simulator of Battleship game!

## Project assumptions
The game is projected to be fully independent in decision from fronted site. Any websie coud use simple API to run battleship. /
It was written based on classical rules. The board has always 10x10 fields and set of ships is also always the same. /
![image](https://user-images.githubusercontent.com/92270179/171295595-dcc76065-f5a7-4b07-8814-30ec68d993f4.png)

### Winning rules


### Rules of ship positioning
Following the rules bot algorithm places ships with at least 1 empty field between them, in vertical and horizonal direction.

### Rules of turns
It is decided randomly which player will start a game. 
At single turn player makes at least one shot. 
If shot misses ship, active player just get that info, to put it at shooting board and roles are changing - second player become an attacking player.
If shot hits ship, acive player gets possibility to make extra shot. Every well-aimed shot generates one more extra shot, until player missed.

### Different shooting algorithms
The way of generating shots depends on situation in game. If it is first shot of current player, it make a shot randomly. /
However if first shot hitted other player ship, attacking player makes "searching shot" in closest neighbours of field, where ship was hitten.

# Screenshots

### Swagger:
![image](https://user-images.githubusercontent.com/92270179/171296727-511c58a1-d10b-4122-864e-b5a7b06c79be.png)
![image](https://user-images.githubusercontent.com/92270179/171296767-3a2de233-ac45-4d39-b70c-142f96f67618.png)

### Frontend:
![image](https://user-images.githubusercontent.com/92270179/171294866-75120e4f-dffd-43ea-ba94-d884e47fc44d.png)
