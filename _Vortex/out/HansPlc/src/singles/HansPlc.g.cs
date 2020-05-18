using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;
using HansPlcConnector.Properties;

[assembly: Vortex.Connector.Attributes.AssemblyPlcCounterPart("{\r\n  \"Types\": [\r\n    {\r\n      \"TypeAttributes\": \"\",\r\n      \"TypeName\": \"enumStationStatus\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 5\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"fbInfluxPerformanceLogging\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 4\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"fbFluentString\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 4\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"fbWorldWeatherWatch\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 4\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"InfluxData\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 1\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"stContinuousValueLimits\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 1\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"stRecipe\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 1\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty OpenMap \\\"https://www.openstreetmap.org/search?query=Kriva#map=13/49.2826/19.4791\\\" }\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"structWeatherStation\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 1\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"RecipeData\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 0\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"Utils\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 0\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"prgInflux\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 3\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"\\\" }\",\r\n      \"TypeName\": \"MAIN\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 3\r\n    },\r\n    {\r\n      \"TypeAttributes\": \"\\n{attribute addProperty Name \\\"Program\\\" }\",\r\n      \"TypeName\": \"prgWeatherStations\",\r\n      \"Namespace\": \"HansPlc\",\r\n      \"TypeMetaInfo\": 3\r\n    }\r\n  ],\r\n  \"Name\": \"HansPlc\",\r\n  \"Namespace\": \"HansPlc\"\r\n}")]
namespace HansPlc
{
	public partial class HansPlcTwinController : Vortex.Connector.ITwinController, IHansPlcTwinController, IShadowHansPlcTwinController
	{
		public string Symbol
		{
			get;
			protected set;
		}

		public string HumanReadable
		{
			get
			{
				return HansPlcTwinController.Translator.Translate(_humanReadable).Interpolate(this);
			}

			protected set
			{
				_humanReadable = value;
			}
		}

		protected string _humanReadable;
		RecipeData _RecipeData;
		public RecipeData RecipeData
		{
			get
			{
				return _RecipeData;
			}
		}

		IRecipeData IHansPlcTwinController.RecipeData
		{
			get
			{
				return RecipeData;
			}
		}

		IShadowRecipeData IShadowHansPlcTwinController.RecipeData
		{
			get
			{
				return RecipeData;
			}
		}

		Utils _Utils;
		public Utils Utils
		{
			get
			{
				return _Utils;
			}
		}

		IUtils IHansPlcTwinController.Utils
		{
			get
			{
				return Utils;
			}
		}

		IShadowUtils IShadowHansPlcTwinController.Utils
		{
			get
			{
				return Utils;
			}
		}

		prgInflux _prgInflux;
		public prgInflux prgInflux
		{
			get
			{
				return _prgInflux;
			}
		}

		IprgInflux IHansPlcTwinController.prgInflux
		{
			get
			{
				return prgInflux;
			}
		}

		IShadowprgInflux IShadowHansPlcTwinController.prgInflux
		{
			get
			{
				return prgInflux;
			}
		}

		MAIN _MAIN;
		public MAIN MAIN
		{
			get
			{
				return _MAIN;
			}
		}

		IMAIN IHansPlcTwinController.MAIN
		{
			get
			{
				return MAIN;
			}
		}

		IShadowMAIN IShadowHansPlcTwinController.MAIN
		{
			get
			{
				return MAIN;
			}
		}

		prgWeatherStations _prgWeatherStations;
		public prgWeatherStations prgWeatherStations
		{
			get
			{
				return _prgWeatherStations;
			}
		}

		IprgWeatherStations IHansPlcTwinController.prgWeatherStations
		{
			get
			{
				return prgWeatherStations;
			}
		}

		IShadowprgWeatherStations IShadowHansPlcTwinController.prgWeatherStations
		{
			get
			{
				return prgWeatherStations;
			}
		}

		public void LazyOnlineToShadow()
		{
			RecipeData.LazyOnlineToShadow();
			Utils.LazyOnlineToShadow();
			prgInflux.LazyOnlineToShadow();
			MAIN.LazyOnlineToShadow();
			prgWeatherStations.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			RecipeData.LazyShadowToOnline();
			Utils.LazyShadowToOnline();
			prgInflux.LazyShadowToOnline();
			MAIN.LazyShadowToOnline();
			prgWeatherStations.LazyShadowToOnline();
		}

		public PlainHansPlcTwinController CreatePlainerType()
		{
			var cloned = new PlainHansPlcTwinController();
			cloned.RecipeData = RecipeData.CreatePlainerType();
			cloned.Utils = Utils.CreatePlainerType();
			cloned.prgInflux = prgInflux.CreatePlainerType();
			cloned.MAIN = MAIN.CreatePlainerType();
			cloned.prgWeatherStations = prgWeatherStations.CreatePlainerType();
			return cloned;
		}

		protected PlainHansPlcTwinController CreatePlainerType(PlainHansPlcTwinController cloned)
		{
			cloned.RecipeData = RecipeData.CreatePlainerType();
			cloned.Utils = Utils.CreatePlainerType();
			cloned.prgInflux = prgInflux.CreatePlainerType();
			cloned.MAIN = MAIN.CreatePlainerType();
			cloned.prgWeatherStations = prgWeatherStations.CreatePlainerType();
			return cloned;
		}

		public System.String AttributeName
		{
			get
			{
				return HansPlcTwinController.Translator.Translate(_AttributeName).Interpolate(this);
			}

			set
			{
				_AttributeName = value;
			}
		}

		private System.String _AttributeName
		{
			get;
			set;
		}

		public IHansPlcTwinController Online
		{
			get
			{
				return (IHansPlcTwinController)this;
			}
		}

		public IShadowHansPlcTwinController Shadow
		{
			get
			{
				return (IShadowHansPlcTwinController)this;
			}
		}

		public Vortex.Connector.IConnector Connector
		{
			get;
			set;
		}

		public HansPlcTwinController()
		{
			var adapter = new Vortex.Connector.ConnectorAdapter(typeof (DummyConnectorFactory));
			this.Connector = adapter.GetConnector(new object[]{});
			_RecipeData = new RecipeData(this.Connector, "", "RecipeData");
			_Utils = new Utils(this.Connector, "", "Utils");
			_prgInflux = new prgInflux(this.Connector, "", "prgInflux");
			_MAIN = new MAIN(this.Connector, "", "MAIN");
			_prgWeatherStations = new prgWeatherStations(this.Connector, "Program", "prgWeatherStations");
		}

		public HansPlcTwinController(Vortex.Connector.ConnectorAdapter adapter, object[] parameters)
		{
			this.Connector = adapter.GetConnector(parameters);
			_RecipeData = new RecipeData(this.Connector, "", "RecipeData");
			_Utils = new Utils(this.Connector, "", "Utils");
			_prgInflux = new prgInflux(this.Connector, "", "prgInflux");
			_MAIN = new MAIN(this.Connector, "", "MAIN");
			_prgWeatherStations = new prgWeatherStations(this.Connector, "Program", "prgWeatherStations");
		}

		public HansPlcTwinController(Vortex.Connector.ConnectorAdapter adapter)
		{
			this.Connector = adapter.GetConnector(adapter.Parameters);
			_RecipeData = new RecipeData(this.Connector, "", "RecipeData");
			_Utils = new Utils(this.Connector, "", "Utils");
			_prgInflux = new prgInflux(this.Connector, "", "prgInflux");
			_MAIN = new MAIN(this.Connector, "", "MAIN");
			_prgWeatherStations = new prgWeatherStations(this.Connector, "Program", "prgWeatherStations");
		}

		public static string LocalizationDirectory
		{
			get;
			set;
		}

		private static Vortex.Localizations.Abstractions.ITranslator _translator
		{
			get;
			set;
		}

		internal static Vortex.Localizations.Abstractions.ITranslator Translator
		{
			get
			{
				if (_translator == null)
				{
					_translator = Vortex.Localizations.Abstractions.ITranslator.Get(typeof (Localizations));
				} return  _translator ; 

			}
		}
	}

	public partial interface IHansPlcTwinController
	{
		IRecipeData RecipeData
		{
			get;
		}

		IUtils Utils
		{
			get;
		}

		IprgInflux prgInflux
		{
			get;
		}

		IMAIN MAIN
		{
			get;
		}

		IprgWeatherStations prgWeatherStations
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainHansPlcTwinController CreatePlainerType();
	}

	public partial interface IShadowHansPlcTwinController
	{
		IShadowRecipeData RecipeData
		{
			get;
		}

		IShadowUtils Utils
		{
			get;
		}

		IShadowprgInflux prgInflux
		{
			get;
		}

		IShadowMAIN MAIN
		{
			get;
		}

		IShadowprgWeatherStations prgWeatherStations
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainHansPlcTwinController CreatePlainerType();
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainHansPlcTwinController : Vortex.Connector.IPlain
	{
		PlainRecipeData _RecipeData;
		public PlainRecipeData RecipeData
		{
			get
			{
				return _RecipeData;
			}

			set
			{
				_RecipeData = value;
			}
		}

		PlainUtils _Utils;
		public PlainUtils Utils
		{
			get
			{
				return _Utils;
			}

			set
			{
				_Utils = value;
			}
		}

		PlainprgInflux _prgInflux;
		public PlainprgInflux prgInflux
		{
			get
			{
				return _prgInflux;
			}

			set
			{
				_prgInflux = value;
			}
		}

		PlainMAIN _MAIN;
		public PlainMAIN MAIN
		{
			get
			{
				return _MAIN;
			}

			set
			{
				_MAIN = value;
			}
		}

		PlainprgWeatherStations _prgWeatherStations;
		public PlainprgWeatherStations prgWeatherStations
		{
			get
			{
				return _prgWeatherStations;
			}

			set
			{
				_prgWeatherStations = value;
			}
		}

		public void CopyPlainToCyclic(HansPlc.HansPlcTwinController target)
		{
			RecipeData.CopyPlainToCyclic(target.RecipeData);
			Utils.CopyPlainToCyclic(target.Utils);
			prgInflux.CopyPlainToCyclic(target.prgInflux);
			MAIN.CopyPlainToCyclic(target.MAIN);
			prgWeatherStations.CopyPlainToCyclic(target.prgWeatherStations);
		}

		public void CopyPlainToCyclic(HansPlc.IHansPlcTwinController target)
		{
			this.CopyPlainToCyclic((HansPlc.HansPlcTwinController)target);
		}

		public void CopyPlainToShadow(HansPlc.HansPlcTwinController target)
		{
			RecipeData.CopyPlainToShadow(target.RecipeData);
			Utils.CopyPlainToShadow(target.Utils);
			prgInflux.CopyPlainToShadow(target.prgInflux);
			MAIN.CopyPlainToShadow(target.MAIN);
			prgWeatherStations.CopyPlainToShadow(target.prgWeatherStations);
		}

		public void CopyPlainToShadow(HansPlc.IShadowHansPlcTwinController target)
		{
			this.CopyPlainToShadow((HansPlc.HansPlcTwinController)target);
		}

		public void CopyCyclicToPlain(HansPlc.HansPlcTwinController source)
		{
			RecipeData.CopyCyclicToPlain(source.RecipeData);
			Utils.CopyCyclicToPlain(source.Utils);
			prgInflux.CopyCyclicToPlain(source.prgInflux);
			MAIN.CopyCyclicToPlain(source.MAIN);
			prgWeatherStations.CopyCyclicToPlain(source.prgWeatherStations);
		}

		public void CopyCyclicToPlain(HansPlc.IHansPlcTwinController source)
		{
			this.CopyCyclicToPlain((HansPlc.HansPlcTwinController)source);
		}

		public void CopyShadowToPlain(HansPlc.HansPlcTwinController source)
		{
			RecipeData.CopyShadowToPlain(source.RecipeData);
			Utils.CopyShadowToPlain(source.Utils);
			prgInflux.CopyShadowToPlain(source.prgInflux);
			MAIN.CopyShadowToPlain(source.MAIN);
			prgWeatherStations.CopyShadowToPlain(source.prgWeatherStations);
		}

		public void CopyShadowToPlain(HansPlc.IShadowHansPlcTwinController source)
		{
			this.CopyShadowToPlain((HansPlc.HansPlcTwinController)source);
		}

		public PlainHansPlcTwinController()
		{
			_RecipeData = new PlainRecipeData();
			_Utils = new PlainUtils();
			_prgInflux = new PlainprgInflux();
			_MAIN = new PlainMAIN();
			_prgWeatherStations = new PlainprgWeatherStations();
		}
	}
}