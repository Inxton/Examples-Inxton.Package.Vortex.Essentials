using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "prgInflux", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class prgInflux : Vortex.Connector.IVortexObject, IprgInflux, IShadowprgInflux, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		fbInfluxPerformanceLogging __influx;
		public fbInfluxPerformanceLogging _influx
		{
			get
			{
				return __influx;
			}
		}

		IfbInfluxPerformanceLogging IprgInflux._influx
		{
			get
			{
				return _influx;
			}
		}

		IShadowfbInfluxPerformanceLogging IShadowprgInflux._influx
		{
			get
			{
				return _influx;
			}
		}

		public void LazyOnlineToShadow()
		{
			_influx.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			_influx.LazyShadowToOnline();
		}

		public PlainprgInflux CreatePlainerType()
		{
			var cloned = new PlainprgInflux();
			cloned._influx = _influx.CreatePlainerType();
			return cloned;
		}

		protected PlainprgInflux CreatePlainerType(PlainprgInflux cloned)
		{
			cloned._influx = _influx.CreatePlainerType();
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

		public void FlushPlainToOnline(HansPlc.PlainprgInflux source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainprgInflux source)
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

		public void FlushOnlineToPlain(HansPlc.PlainprgInflux source)
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

		public prgInflux(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			__influx = new fbInfluxPerformanceLogging(this, "", "_influx");
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public prgInflux()
		{
			PexPreConstructorParameterless();
			__influx = new fbInfluxPerformanceLogging();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcprgInflux
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcprgInflux()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IprgInflux : Vortex.Connector.IVortexOnlineObject
	{
		IfbInfluxPerformanceLogging _influx
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgInflux CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainprgInflux source);
		void FlushOnlineToPlain(HansPlc.PlainprgInflux source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowprgInflux : Vortex.Connector.IVortexShadowObject
	{
		IShadowfbInfluxPerformanceLogging _influx
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgInflux CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainprgInflux source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainprgInflux : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainfbInfluxPerformanceLogging __influx;
		public PlainfbInfluxPerformanceLogging _influx
		{
			get
			{
				return __influx;
			}

			set
			{
				if (__influx != value)
				{
					__influx = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(_influx)));
				}
			}
		}

		public void CopyPlainToCyclic(HansPlc.prgInflux target)
		{
			_influx.CopyPlainToCyclic(target._influx);
		}

		public void CopyPlainToCyclic(HansPlc.IprgInflux target)
		{
			this.CopyPlainToCyclic((HansPlc.prgInflux)target);
		}

		public void CopyPlainToShadow(HansPlc.prgInflux target)
		{
			_influx.CopyPlainToShadow(target._influx);
		}

		public void CopyPlainToShadow(HansPlc.IShadowprgInflux target)
		{
			this.CopyPlainToShadow((HansPlc.prgInflux)target);
		}

		public void CopyCyclicToPlain(HansPlc.prgInflux source)
		{
			_influx.CopyCyclicToPlain(source._influx);
		}

		public void CopyCyclicToPlain(HansPlc.IprgInflux source)
		{
			this.CopyCyclicToPlain((HansPlc.prgInflux)source);
		}

		public void CopyShadowToPlain(HansPlc.prgInflux source)
		{
			_influx.CopyShadowToPlain(source._influx);
		}

		public void CopyShadowToPlain(HansPlc.IShadowprgInflux source)
		{
			this.CopyShadowToPlain((HansPlc.prgInflux)source);
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainprgInflux()
		{
			__influx = new PlainfbInfluxPerformanceLogging();
		}
	}
}