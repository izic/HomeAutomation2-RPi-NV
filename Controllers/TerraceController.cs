using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

using System.ServiceModel;

namespace HomeAutomation.Controllers
{
	public class TerraceController : Controller
	{
		public ActionResult Index ()
		{
			return View ();
		}

		public ActionResult StartWatering (int? interval)
		{	
			var res = false;

			var binding = new BasicHttpBinding ();
			var address = new EndpointAddress ("http://localhost:8090");
			//var client = new Client.MyServiceClient (binding, address);

			//var res = client.StartWatering (interval);

			ViewData["WateringInterval"] = interval;
			ViewData["WateringResult"] = res;

			return View ();
		}

		public ActionResult StopWatering ()
		{	
			var binding = new BasicHttpBinding ();
			var address = new EndpointAddress ("http://localhost:8090");
			var client = new Client.MyServiceClient (binding, address);

			var res = client.StopWatering ();			
			return View ();
		}


		public ActionResult ReadWateringState ()
		{	
			var binding = new BasicHttpBinding ();
			var address = new EndpointAddress ("http://localhost:8090");
			var client = new Client.MyServiceClient (binding, address);

			var value = client.ReadWateringState ();
			ViewData ["WateringState"] = value;
			return View ();
		}

		public ActionResult CheckWaterTankLevel ()
		{	
			var binding = new BasicHttpBinding ();
			var address = new EndpointAddress ("http://localhost:8090");
			var client = new Client.MyServiceClient (binding, address);

			var value = client.CheckWaterTankLevel ();
			ViewData ["WaterTankLevel"] = value;
			return View ();
		}

	}
}

