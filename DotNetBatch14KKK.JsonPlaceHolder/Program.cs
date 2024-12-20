// See https://aka.ms/new-console-template for more information
using DotNetBatch14KKK.JsonPlaceHolder;

Console.WriteLine("Hello, World!");

//JsonRefitService JsonRefitService = new JsonRefitService();
//var lst = await JsonRefitService.GetJsons();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.title);
//}

//JsonHttpClient JsonHttpClient = new JsonHttpClient();
//var lst = await JsonHttpClient.GetJsons();

//foreach (var item in lst)
//{
//    Console.WriteLine(item.title);
//}

JsonRestClient JsonRestClient = new JsonRestClient();
var lst = await JsonRestClient.GetJsons();

foreach (var item in lst)
{
    Console.WriteLine(item.title);
}
Console.ReadLine();