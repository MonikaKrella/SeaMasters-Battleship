![seamlogo](https://user-images.githubusercontent.com/92270179/171294801-928f97ea-0a46-44bc-9d33-23662bb6741a.png)

# SeaMasters-Battleship
Your simulator of the Battleship game!

## Project assumptions
The game is designed in a way that server is fully responsible for executing game logic. Any website can use this API to run battleship. 
If you want to see frontend part prepaired for this simulator, visit: https://github.com/MonikaKrella/SeaMastersFront

### Technical issues
 - Data from server is avaiable by simple API, with two endpoinds for creating game and making player's turn. 
 - It's using a single game manager for all clients and storing their games by games' ids, which is necessary for getting data about every turn.

### Different shooting algorithms
The way of generating shots depends on situation in game. If it is first shot of current player, it make a shot randomly.
However if first shot hitted other player ship, attacking player makes "searching shot" in closest neighbours of field, where ship was hitten.

## Rules
It was written based on classical rules. The board has always 10x10 fields and set of ships is also always the same.

### Rules of ship positioning
Following the rules bot algorithm places ships with at least 1 empty field between them, in vertical and horizonal direction.

### Rules of turns
It is decided randomly which player will start a game. 
At single turn player makes at least one shot. 
If shot misses, active player just get that info to put it at shooting board. Then roles are changing - second player becomes an attacking player.
If shot is a hit, acive player gets possibility to make extra shot. Every well-aimed shot generates one more extra shot until player missed.

### Winning rules
The big battle is won by the pirate, who first destroys all enemies ships. At that moment game is finished.

# Tech stack
 - ASP.NET 6
 - .NET 10
 - Newtonsoft.Json

# Ideas for future
 - tests
 - mamanging player vs computer mode
 - managing player vs player mode

# Screenshots

### Swagger:
![image](https://user-images.githubusercontent.com/92270179/171396942-af19d192-794b-4c40-8abd-487c85f1be3a.png)
![image](https://user-images.githubusercontent.com/92270179/171296767-3a2de233-ac45-4d39-b70c-142f96f67618.png)

### Frontend:
![image](https://user-images.githubusercontent.com/92270179/171294866-75120e4f-dffd-43ea-ba94-d884e47fc44d.png)
