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
              <li class="pure-menu-item"><a href="active.php" class="pure-menu-heading ">All Active Users</a></li>
              <li class="pure-menu-item"><a href="logs.php" class="pure-menu-link">See Logs</a></li>
          </ul>
      </div>

<CENTER>
<table class="pure-table">
        <thead>
            <tr>
                <th>IP</th>
                <th>Status</th>
                <th>Date Of Connection</th>
            </tr>
        </thead>
    
        
   
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

$sql = "call getActive()";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
     // output data of each row
     while($row = $result->fetch_assoc()) {

         echo " <tbody> 
              <tr>
               <td>". $row["ip"] . "</td>
               <td>". $row["logstatus"] . "</td>
                <td>".$row["connect_date"]. "</td>
                 <tr> 
                 </tbody>";
       
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