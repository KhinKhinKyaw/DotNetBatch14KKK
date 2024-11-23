using System.Data;
using ConsoleApp3.AdoDotNetExamples1;
using ConsoleApp3.DapperExamples1;
using ConsoleApp3.EFCoreExamples1;
using Microsoft.Data.SqlClient;


AdoDotNetExamples1 adoDotNetExamples1 = new AdoDotNetExamples1();
//adoDotNetExamples1.Read();
//adoDotNetExamples1.Edit("3");
//adoDotNetExamples1.Create("Sara", "Sara1", "Testing");
//adoDotNetExamples1.update("3", "Style");
//adoDotNetExamples1.Delete("3");
DapperExamples1 dapperExamples = new DapperExamples1();
//dapperExamples1.Read();
//dapperExamples1.Edit("4");
//dapperExamples1.Create("D.O","EXO","Vocal");
//dapperExamples1.Update("4", "WAWA");
//dapperExamples1.Delete("4");
EFCoreExamples1 EFCoreExamples1 = new EFCoreExamples1();
//EFCoreExamples1.Edit("722736d8-f31c-49c1-8416-0dede3c1e770");
EFCoreExamples1.Update("722736d8-f31c-49c1-8416-0dede3c1e770", "Harry", "Potter", "HarryPotter");