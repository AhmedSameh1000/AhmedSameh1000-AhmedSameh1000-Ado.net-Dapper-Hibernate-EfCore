namespace EfCore6
{
	public class Program
	{
		static void Main(string[] args)
		{
		
		}
	}
}
// Step #1: Package Manager Console (PMC)
//    Tools -> Nuget Package Manager -> Package Manager Console

// Step #2: Package Manager Console (PMC) Tool 
//    Install-Package Microsoft.EntityFrameworkCore.Tools

// Step #3: Install Nuget Page on Project Microsoft.EntityFrameworkCore.Design
// Microsoft.EntityFrameworkCore.SqlServer

// Step #4: Install Provider in the project Microsoft.EntityFrameworkCore.SqlServer

// Step #5: Run Command (Full)
//    Scaffold-DbContext '[Connection String]' [Provider]


/*
 Scaffold-DbContext
'Data Source=NEXUSLITE-PC\SQLEXPRESS;Initial Catalog=TechTalk;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False'
Microsoft.EntityFrameworkCore.SqlServer 
-Context AppDbContext
-ContextDir Data
-o Entities 
-Tables Ahmed 
-Force
 */

