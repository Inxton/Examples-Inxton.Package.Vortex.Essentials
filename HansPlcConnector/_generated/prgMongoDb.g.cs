using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "prgMongoDb", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class prgMongoDb : Vortex.Connector.IVortexObject, IprgMongoDb, IShadowprgMongoDb, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.Online.IOnlineULInt IprgMongoDb._logStart
		{
			get
			{
				return _logStart;
			}
		}

		[ReadOnly(), CompilerOmits("BuilderPlainer"), RenderIgnore()]
		Vortex.Connector.ValueTypes.Shadows.IShadowULInt IShadowprgMongoDb._logStart
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
		Vortex.Connector.ValueTypes.Online.IOnlineULInt IprgMongoDb._logDone
		{
			get
			{
				return _logDone;
			}
		}

		[RenderIgnore(), CompilerOmits("BuilderPlainer")]
		Vortex.Connector.ValueTypes.Shadows.IShadowULInt IShadowprgMongoDb._logDone
		{
			get
			{
				return _logDone;
			}
		}

		structMongoData __data;
		public structMongoData _data
		{
			get
			{
				return __data;
			}
		}

		IstructMongoData IprgMongoDb._data
		{
			get
			{
				return _data;
			}
		}

		IShadowstructMongoData IShadowprgMongoDb._data
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

		public PlainprgMongoDb CreatePlainerType()
		{
			var cloned = new PlainprgMongoDb();
			cloned._data = _data.CreatePlainerType();
			return cloned;
		}

		protected PlainprgMongoDb CreatePlainerType(PlainprgMongoDb cloned)
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

		public void FlushPlainToOnline(HansPlc.PlainprgMongoDb source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainprgMongoDb source)
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

		public void FlushOnlineToPlain(HansPlc.PlainprgMongoDb source)
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

		public prgMongoDb(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
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
			__data = new structMongoData(this, "", "_data");
			AttributeName = "";
			parent.AddChild(this);
			parent.AddKid(this);
			PexConstructor(parent, readableTail, symbolTail);
		}

		public prgMongoDb()
		{
			PexPreConstructorParameterless();
			__logStart = Vortex.Connector.IConnectorFactory.CreateULINT();
			__logDone = Vortex.Connector.IConnectorFactory.CreateULINT();
			__data = new structMongoData();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcprgMongoDb
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcprgMongoDb()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IprgMongoDb : Vortex.Connector.IVortexOnlineObject
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

		IstructMongoData _data
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgMongoDb CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainprgMongoDb source);
		void FlushOnlineToPlain(HansPlc.PlainprgMongoDb source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowprgMongoDb : Vortex.Connector.IVortexShadowObject
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

		IShadowstructMongoData _data
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgMongoDb CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainprgMongoDb source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainprgMongoDb : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		PlainstructMongoData __data;
		public PlainstructMongoData _data
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

		public void CopyPlainToCyclic(HansPlc.prgMongoDb target)
		{
			_data.CopyPlainToCyclic(target._data);
		}

		public void CopyPlainToCyclic(HansPlc.IprgMongoDb target)
		{
			this.CopyPlainToCyclic((HansPlc.prgMongoDb)target);
		}

		public void CopyPlainToShadow(HansPlc.prgMongoDb target)
		{
			_data.CopyPlainToShadow(target._data);
		}

		public void CopyPlainToShadow(HansPlc.IShadowprgMongoDb target)
		{
			this.CopyPlainToShadow((HansPlc.prgMongoDb)target);
		}

		public void CopyCyclicToPlain(HansPlc.prgMongoDb source)
		{
			_data.CopyCyclicToPlain(source._data);
		}

		public void CopyCyclicToPlain(HansPlc.IprgMongoDb source)
		{
			this.CopyCyclicToPlain((HansPlc.prgMongoDb)source);
		}

		public void CopyShadowToPlain(HansPlc.prgMongoDb source)
		{
			_data.CopyShadowToPlain(source._data);
		}

		public void CopyShadowToPlain(HansPlc.IShadowprgMongoDb source)
		{
			this.CopyShadowToPlain((HansPlc.prgMongoDb)source);
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainprgMongoDb()
		{
			__data = new PlainstructMongoData();
		}
	}
}