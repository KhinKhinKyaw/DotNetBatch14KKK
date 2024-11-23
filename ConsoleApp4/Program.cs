using System.Data;
using ConsoleApp4.AdoDotNetExamples2;
using ConsoleApp4.DapperExamples2;
using ConsoleApp4.EFCoreExamples2;
using Microsoft.Data.SqlClient;

AdoDotNetExamples2 adoDotNetExample = new AdoDotNetExamples2();
adoDotNetExample.Read();
//adoDotNetExample.Edit("1");
//adoDotNetExample.Create("Potter", "Expreto", "Lvosal");
//adoDotNetExample.update("1", "BB");
//adoDotNetExample.Delete("1");
DapperExamples2 dapperExamples = new DapperExamples2();
//dapperExamples.Read();
//dapperExamples.Edit("2");
//dapperExamples.Create("Chanyeol","EXO","Rapper");
//dapperExamples.Update("2", "HarryPotter");
//dapperExamples.Delete("2");
EFCoreExamples2 eFCoreExample = new EFCoreExamples2();
//eFCoreExample.Read();
eFCoreExample.Edit("722736d8-f31c-49c1-8416-0dede3c1e770");
//eFCoreExample.Create("sc", "sc1", "sc2");

//eFCoreExample.Update("1", "Harry", "Potter", "HP");