using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "fbInfluxPerformanceLogging", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class fbInfluxPerformanceLogging : Vortex.Connector.IVortexObject, IfbInfluxPerformanceLogging, IShadowfbInfluxPerformanceLogging, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerULInt __logStart;
		[ReadOnly(), CompilerOmits("BuilderPlainer"), RenderIgnore()]
		public Vortex.Connector.ValueTypes.OnlinerULInt _logStart
		{
			get
			{
				return __logStart;
			}
		}

		[ReadOnly(), CompilerOmits("BuilderPlainer"), RenderIgnore()]
		Vortex.Connector.ValueTypes.Online.IOnlineULInt IfbInfluxPerformanceLogging._logStart
		{
			get
			{
				return _logStart;
			}
		}

		[ReadOnly(), CompilerOmits("BuilderPlainer"), RenderIgnore()]
		Vortex.Connector.ValueTypes.Shadows.IShadowULInt IShadowfbInfluxPerformanceLogging._logStart
		{
			get
			{
				return _logStart;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerULInt __logDone;
		[RenderIgnore(), CompilerOmits("BuilderPlainer")]
		public Vortex.Connector.ValueTypes.OnlinerULInt _logDone
		{
			get
			{
				return __logDone;
			}
		}

		[RenderIgnore(), CompilerOmits("BuilderPlainer")]
		Vortex.Connector.ValueTypes.Online.IOnlineULInt IfbInfluxPerformanceLogging._logDone
		{
			get
			{
				return _logDone;
			}
		}

		[RenderIgnore(), CompilerOmits("BuilderPlainer")]
		Vortex.Connector.ValueTypes.Shadows.IShadowULInt IShadowfbInfluxPerformanceLogging._logDone
		{
			get
			{
				return _logDone;
			}
		}

		InfluxData __data;
		public InfluxData _data
		{
			get
			{
				return __data;
			}
		}

		IInfluxData IfbInfluxPerformanceLogging._data
		{
			get
			{
				return _data;
			}
		}

		IShadowInfluxData IShadowfbInfluxPerformanceLogging._data
		{
			get
			{
				return _data;
			}
		}

		public void LazyOnlineToShadow()
		{
			_logStart.Shadow = _logStart.LastValue;
			_logDone.Shadow = _logDone.LastValue;
			_data.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			_logStart.Cyclic = _logStart.Shadow;
			_logDone.Cyclic = _logDone.Shadow;
			_data.LazyShadowToOnline();
		}

		public PlainfbInfluxPerformanceLogging CreatePlainerType()
		{
			var cloned = new PlainfbInfluxPerformanceLogging();
			cloned._data = _data.CreatePlainerType();
			return cloned;
		}

		protected PlainfbInfluxPerformanceLogging CreatePlainerType(PlainfbInfluxPerformanceLogging cloned)
		{
			cloned._data = _data.CreatePlainerType();
			return cloned;
		}

		partial void PexPreConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexPreConstructorParameterless();
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

		private System.Collections.Generic.List<Vortex.Connector.IVortexElement> Kids
		{
			get;
			set;
		}

		public System.Collections.Generic.IEnumerable<Vortex.Connector.IVortexElement> GetKids()
		{
			return this.Kids;
		}

		public void AddKid(Vortex.Connector.IVortexElement vortexElement)
		{
			this.Kids.Add(vortexElement);
		}

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

		public void FlushPlainToOnline(HansPlc.PlainfbInfluxPerformanceLogging source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainfbInfluxPerformanceLogging source)
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

		public void FlushOnlineToPlain(HansPlc.PlainfbInfluxPerformanceLogging source)
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

		public fbInfluxPerformanceLogging(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			this.Kids = new System.Collections.Generic.List<Vortex.Connector.IVortexElement>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			__logStart = @Connector.Online.Adapter.CreateULINT(this, "", "_logStart");
			_logStart.MakeReadOnly();
			__logDone = @Connector.Online.Adapter.CreateULINT(this, "", "_logDone");
			__data = new InfluxData(this, "", "_data");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public fbInfluxPerformanceLogging()
		{
			PexPreConstructorParameterless();
			__logStart = Vortex.Connector.IConnectorFactory.CreateULINT();
			__logDone = Vortex.Connector.IConnectorFactory.CreateULINT();
			__data = new InfluxData();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcfbInfluxPerformanceLogging
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcfbInfluxPerformanceLogging()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IfbInfluxPerformanceLogging : Vortex.Connector.IVortexOnlineObject
	{
		[ReadOnly(), CompilerOmits("BuilderPlainer"), RenderIgnore()]
		Vortex.Connector.ValueTypes.Online.IOnlineULInt _logStart
		{
			get;
		}

		[RenderIgnore(), CompilerOmits("BuilderPlainer")]
		Vortex.Connector.ValueTypes.Online.IOnlineULInt _logDone
		{
			get;
		}

		IInfluxData _data
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainfbInfluxPerformanceLogging CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainfbInfluxPerformanceLogging source);
		void FlushOnlineToPlain(HansPlc.PlainfbInfluxPerformanceLogging source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowfbInfluxPerformanceLogging : Vortex.Connector.IVortexShadowObject
	{
		[ReadOnly(), CompilerOmits("BuilderPlainer"), RenderIgnore()]
		Vortex.Connector.ValueTypes.Shadows.IShadowULInt _logStart
		{
			get;
		}

		[RenderIgnore(), CompilerOmits("BuilderPlainer")]
		Vortex.Connector.ValueTypes.Shadows.IShadowULInt _logDone
		{
			get;
		}

		IShadowInfluxData _data
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainfbInfluxPerformanceLogging CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainfbInfluxPerformanceLogging source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainfbInfluxPerformanceLogging : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainInfluxData __data;
		public PlainInfluxData _data
		{
			get
			{
				return __data;
			}

			set
			{
				if (__data != value)
				{
					__data = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(_data)));
				}
			}
		}

		public void CopyPlainToCyclic(HansPlc.fbInfluxPerformanceLogging target)
		{
			_data.CopyPlainToCyclic(target._data);
		}

		public void CopyPlainToCyclic(HansPlc.IfbInfluxPerformanceLogging target)
		{
			this.CopyPlainToCyclic((HansPlc.fbInfluxPerformanceLogging)target);
		}

		public void CopyPlainToShadow(HansPlc.fbInfluxPerformanceLogging target)
		{
			_data.CopyPlainToShadow(target._data);
		}

		public void CopyPlainToShadow(HansPlc.IShadowfbInfluxPerformanceLogging target)
		{
			this.CopyPlainToShadow((HansPlc.fbInfluxPerformanceLogging)target);
		}

		public void CopyCyclicToPlain(HansPlc.fbInfluxPerformanceLogging source)
		{
			_data.CopyCyclicToPlain(source._data);
		}

		public void CopyCyclicToPlain(HansPlc.IfbInfluxPerformanceLogging source)
		{
			this.CopyCyclicToPlain((HansPlc.fbInfluxPerformanceLogging)source);
		}

		public void CopyShadowToPlain(HansPlc.fbInfluxPerformanceLogging source)
		{
			_data.CopyShadowToPlain(source._data);
		}

		public void CopyShadowToPlain(HansPlc.IShadowfbInfluxPerformanceLogging source)
		{
			this.CopyShadowToPlain((HansPlc.fbInfluxPerformanceLogging)source);
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainfbInfluxPerformanceLogging()
		{
			__data = new PlainInfluxData();
		}
	}
}