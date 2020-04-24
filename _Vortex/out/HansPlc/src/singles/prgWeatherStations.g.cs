using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"Program\" }", "prgWeatherStations", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class prgWeatherStations : Vortex.Connector.IVortexObject, IprgWeatherStations, IShadowprgWeatherStations, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		fbWorldWeatherWatch __weatherStations;
		public fbWorldWeatherWatch _weatherStations
		{
			get
			{
				return __weatherStations;
			}
		}

		IfbWorldWeatherWatch IprgWeatherStations._weatherStations
		{
			get
			{
				return _weatherStations;
			}
		}

		IShadowfbWorldWeatherWatch IShadowprgWeatherStations._weatherStations
		{
			get
			{
				return _weatherStations;
			}
		}

		public void LazyOnlineToShadow()
		{
			_weatherStations.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			_weatherStations.LazyShadowToOnline();
		}

		public PlainprgWeatherStations CreatePlainerType()
		{
			var cloned = new PlainprgWeatherStations();
			cloned._weatherStations = _weatherStations.CreatePlainerType();
			return cloned;
		}

		protected PlainprgWeatherStations CreatePlainerType(PlainprgWeatherStations cloned)
		{
			cloned._weatherStations = _weatherStations.CreatePlainerType();
			return cloned;
		}

		partial void PexPreConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexPreConstructorParameterless();
		partial void PexConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexConstructorParameterless();
		protected Vortex.Connector.IVortexObject @Parent
		{
			get;
			set;
		}

		public Vortex.Connector.IVortexObject GetParent()
		{
			return this.@Parent;
		}

		private System.Collections.Generic.List<Vortex.Connector.IVortexObject> @Children
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IVortexObject> @GetChildren()
		{
			return this.@Children;
		}

		public void AddChild(Vortex.Connector.IVortexObject vortexObject)
		{
			this.@Children.Add(vortexObject);
		}

		private System.Collections.Generic.List<Vortex.Connector.IValueTag> @ValueTags
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IValueTag> GetValueTags()
		{
			return this.@ValueTags;
		}

		public void AddValueTag(Vortex.Connector.IValueTag valueTag)
		{
			this.@ValueTags.Add(valueTag);
		}

		protected Vortex.Connector.IConnector @Connector
		{
			get;
			set;
		}

		public Vortex.Connector.IConnector GetConnector()
		{
			return this.@Connector;
		}

		public void FlushPlainToOnline(HansPlc.PlainprgWeatherStations source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainprgWeatherStations source)
		{
			source.CopyPlainToShadow(this);
		}

		public void FlushShadowToOnline()
		{
			this.LazyShadowToOnline();
			this.Write();
		}

		public void FlushOnlineToShadow()
		{
			this.Read();
			this.LazyOnlineToShadow();
		}

		public void FlushOnlineToPlain(HansPlc.PlainprgWeatherStations source)
		{
			this.Read();
			source.CopyCyclicToPlain(this);
		}

		protected System.String @SymbolTail
		{
			get;
			set;
		}

		public System.String GetSymbolTail()
		{
			return this.SymbolTail;
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

		public prgWeatherStations(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			__weatherStations = new fbWorldWeatherWatch(this, "Weather Cyclic", "_weatherStations");
			__weatherStations.AttributeName = "Weather Cyclic";
			AttributeName = "Program";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public prgWeatherStations()
		{
			PexPreConstructorParameterless();
			__weatherStations = new fbWorldWeatherWatch();
			__weatherStations.AttributeName = "Weather Cyclic";
			AttributeName = "Program";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcprgWeatherStations
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcprgWeatherStations()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IprgWeatherStations : Vortex.Connector.IVortexOnlineObject
	{
		IfbWorldWeatherWatch _weatherStations
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgWeatherStations CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainprgWeatherStations source);
		void FlushOnlineToPlain(HansPlc.PlainprgWeatherStations source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowprgWeatherStations : Vortex.Connector.IVortexShadowObject
	{
		IShadowfbWorldWeatherWatch _weatherStations
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgWeatherStations CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainprgWeatherStations source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainprgWeatherStations : Vortex.Connector.IPlain
	{
		PlainfbWorldWeatherWatch __weatherStations;
		public PlainfbWorldWeatherWatch _weatherStations
		{
			get
			{
				return __weatherStations;
			}

			set
			{
				__weatherStations = value;
			}
		}

		public void CopyPlainToCyclic(HansPlc.prgWeatherStations target)
		{
			_weatherStations.CopyPlainToCyclic(target._weatherStations);
		}

		public void CopyPlainToCyclic(HansPlc.IprgWeatherStations target)
		{
			this.CopyPlainToCyclic((HansPlc.prgWeatherStations)target);
		}

		public void CopyPlainToShadow(HansPlc.prgWeatherStations target)
		{
			_weatherStations.CopyPlainToShadow(target._weatherStations);
		}

		public void CopyPlainToShadow(HansPlc.IShadowprgWeatherStations target)
		{
			this.CopyPlainToShadow((HansPlc.prgWeatherStations)target);
		}

		public void CopyCyclicToPlain(HansPlc.prgWeatherStations source)
		{
			_weatherStations.CopyCyclicToPlain(source._weatherStations);
		}

		public void CopyCyclicToPlain(HansPlc.IprgWeatherStations source)
		{
			this.CopyCyclicToPlain((HansPlc.prgWeatherStations)source);
		}

		public void CopyShadowToPlain(HansPlc.prgWeatherStations source)
		{
			_weatherStations.CopyShadowToPlain(source._weatherStations);
		}

		public void CopyShadowToPlain(HansPlc.IShadowprgWeatherStations source)
		{
			this.CopyShadowToPlain((HansPlc.prgWeatherStations)source);
		}

		public PlainprgWeatherStations()
		{
			__weatherStations = new PlainfbWorldWeatherWatch();
		}
	}
}