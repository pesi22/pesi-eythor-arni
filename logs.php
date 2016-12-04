<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <title>View Logs</title>
  <link rel="stylesheet" href="https://unpkg.com/purecss@0.6.0/build/pure-min.css">
  <link rel="stylesheet" type="text/css" href="css.css">
</head>
<body>

<div class="pure-menu pure-menu-horizontal pure-menu-scrollable">
          <ul class="pure-menu-list">
              <li class="pure-menu-item"><a href="index.php" class="pure-menu-link">All Users</a></li>
              <li class="pure-menu-item"><a href="active.php" class="pure-menu-link">All Active Users</a></li>
              <li class="pure-menu-item"><a href="logs.php" class="pure-menu-heading ">See Logs</a></li>
          </ul>
      </div>
      <h2>Find Log by IP</h2>
      <form id="myForm" action="findlog.php" method="post" class="pure-form">
        <fieldset>
            <input type="text" placeholder="IP adress" name="ip">
           <button type="submit" class="pure-button pure-button-primary">Find IP adress</button>
        </fieldset>
    </form>
    <h4>or</h4>
    <a class="pure-button pure-button-primary" href="alllogs.php">Get All Saved Logs</a>

<CENTER>
<h1> LIST OF ALL LOGGED IP'S:</h1> <h5>
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

         echo "<h5>". $row["logger_ip"] . "</h5>";
       
     }
} else {
     echo "0 results";
}

$conn->close();




?>  

 </table>

</CENTER>
</body>
</html>