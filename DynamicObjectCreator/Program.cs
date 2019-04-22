using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Landstar.Cloud.Models.Mulesoft.Transportation.Order;
using Newtonsoft.Json;

namespace DynamicObjectCreator
{
  class Program
  {
    static void Main(string[] args)
    {
      var settings = new JsonSerializerSettings
      {
        ContractResolver = new LongNameContractResolver(),
        Formatting = Formatting.Indented,
        NullValueHandling = NullValueHandling.Ignore
      };

      var orderDetail = CreateObject.Create<OrderDetail>();
      var json = JsonConvert.SerializeObject(orderDetail, settings);

      //var list = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);
      //foreach (var item in list)
      //{
      //  foreach (KeyValuePair<string, object> keyVal in item)
      //  {
      //    Console.WriteLine($"{keyVal.Key}: {keyVal.Value?.ToString()}");
      //  }
      //}

      //var json2 = JsonConvert.SerializeObject(list, settings);


      Console.WriteLine(json);
      Console.WriteLine("press any key to exit");
      var logFile = Path.Combine(Directory.GetCurrentDirectory(), "output.json");

      File.WriteAllText(logFile, json);
      Console.WriteLine(logFile);
      Console.ReadLine();
    }
  }
}
