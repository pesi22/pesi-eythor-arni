<?php
	class dbTenging
	{
		public function __construct($connection_name)
		{
			
			if(!empty($connection_name)){

				$this->connection = $connection_name;
			}
			else{
				throw new Exception("cant connect to database");
			}
		}
		
		public function getLogs($ip)//Get logs from a specific IP
		{

			$statement = $this->connection->prepare('call getLogs(?)');
			$statement->bindParam(1,$ip);
			
			try 
			{
				$statement->execute();
				
				return $statement;
			}
			catch(PDOException $e)
			{
				return false;
			}
		}
		public function getLoggers()//Gets a list of all loggers that have connected
		{

			$statement = $this->connection->prepare('call getLoggers()');
			try 
			{
				$statement->execute();
				
				return $statement;
			}
			catch(PDOException $e)
			{
				return false;
			}
		}
		public function getActive()//Gets all active users
		{

			$statement = $this->connection->prepare('call getActive()');
			
			try 
			{
				$statement->execute();
				
				return $statement;
			}
			catch(PDOException $e)
			{
				return false;
			}
		}
		public function clearActive()//Clears all active loggers 
		{

			$statement = $this->connection->prepare('call clearActive()');
			
			try 
			{
				$statement->execute();
				
				return $statement;
			}
			catch(PDOException $e)
			{
				return false;
			}
		}
		public function addLogger($ip)//Adds a logger into logger list and active logger list. Tekur inn Ip tölu
		{

			$statement = $this->connection->prepare('call addLogger(?)');
			$statement->bindParam(1,$ip);
			
			try 
			{
				$statement->execute();
				
				return $statement;
			}
			catch(PDOException $e)
			{
				return false;
			}
		}
		public function addLog($ip, $loggs)//Adds a logger into logger list and active logger list. Tekur inn Ip tölu
		{

			$statement = $this->connection->prepare('call addLog(?,?)');
			$statement->bindParam(1,$loggs);
			$statement->bindParam(2,$ip);
			
			try 
			{
				$statement->execute();
				
				return $statement;
			}
			catch(PDOException $e)
			{
				return false;
			}
		}

		
	
		
	}
?>