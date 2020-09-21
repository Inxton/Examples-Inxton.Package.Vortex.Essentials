using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "fbSimpleRemoteExec", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class fbSimpleRemoteExec : Vortex.Connector.IVortexObject, IfbSimpleRemoteExec, IShadowfbSimpleRemoteExec, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerUInt __start;
		public Vortex.Connector.ValueTypes.OnlinerUInt _start
		{
			get
			{
				return __start;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUInt IfbSimpleRemoteExec._start
		{
			get
			{
				return _start;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUInt IShadowfbSimpleRemoteExec._start
		{
			get
			{
				return _start;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerUInt __done;
		public Vortex.Connector.ValueTypes.OnlinerUInt _done
		{
			get
			{
				return __done;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUInt IfbSimpleRemoteExec._done
		{
			get
			{
				return _done;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUInt IShadowfbSimpleRemoteExec._done
		{
			get
			{
				return _done;
			}
		}

		public void LazyOnlineToShadow()
		{
			_start.Shadow = _start.LastValue;
			_done.Shadow = _done.LastValue;
		}

		public void LazyShadowToOnline()
		{
			_start.Cyclic = _start.Shadow;
			_done.Cyclic = _done.Shadow;
		}

		public PlainfbSimpleRemoteExec CreatePlainerType()
		{
			var cloned = new PlainfbSimpleRemoteExec();
			return cloned;
		}

		protected PlainfbSimpleRemoteExec CreatePlainerType(PlainfbSimpleRemoteExec cloned)
		{
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

		public void FlushPlainToOnline(HansPlc.PlainfbSimpleRemoteExec source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainfbSimpleRemoteExec source)
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

		public void FlushOnlineToPlain(HansPlc.PlainfbSimpleRemoteExec source)
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

		public fbSimpleRemoteExec(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			__start = @Connector.Online.Adapter.CreateUINT(this, "", "_start");
			__done = @Connector.Online.Adapter.CreateUINT(this, "", "_done");
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public fbSimpleRemoteExec()
		{
			PexPreConstructorParameterless();
			__start = Vortex.Connector.IConnectorFactory.CreateUINT();
			__done = Vortex.Connector.IConnectorFactory.CreateUINT();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcfbSimpleRemoteExec
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcfbSimpleRemoteExec()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IfbSimpleRemoteExec : Vortex.Connector.IVortexOnlineObject
	{
		Vortex.Connector.ValueTypes.Online.IOnlineUInt _start
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUInt _done
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainfbSimpleRemoteExec CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainfbSimpleRemoteExec source);
		void FlushOnlineToPlain(HansPlc.PlainfbSimpleRemoteExec source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowfbSimpleRemoteExec : Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.Shadows.IShadowUInt _start
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUInt _done
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainfbSimpleRemoteExec CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainfbSimpleRemoteExec source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainfbSimpleRemoteExec : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
	{
		System.UInt16 __start;
		public System.UInt16 _start
		{
			get
			{
				return __start;
			}

			set
			{
				if (__start != value)
				{
					__start = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(_start)));
				}
			}
		}

		System.UInt16 __done;
		public System.UInt16 _done
		{
			get
			{
				return __done;
			}

			set
			{
				if (__done != value)
				{
					__done = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(_done)));
				}
			}
		}

		public void CopyPlainToCyclic(HansPlc.fbSimpleRemoteExec target)
		{
			target._start.Cyclic = _start;
			target._done.Cyclic = _done;
		}

		public void CopyPlainToCyclic(HansPlc.IfbSimpleRemoteExec target)
		{
			this.CopyPlainToCyclic((HansPlc.fbSimpleRemoteExec)target);
		}

		public void CopyPlainToShadow(HansPlc.fbSimpleRemoteExec target)
		{
			target._start.Shadow = _start;
			target._done.Shadow = _done;
		}

		public void CopyPlainToShadow(HansPlc.IShadowfbSimpleRemoteExec target)
		{
			this.CopyPlainToShadow((HansPlc.fbSimpleRemoteExec)target);
		}

		public void CopyCyclicToPlain(HansPlc.fbSimpleRemoteExec source)
		{
			_start = source._start.LastValue;
			_done = source._done.LastValue;
		}

		public void CopyCyclicToPlain(HansPlc.IfbSimpleRemoteExec source)
		{
			this.CopyCyclicToPlain((HansPlc.fbSimpleRemoteExec)source);
		}

		public void CopyShadowToPlain(HansPlc.fbSimpleRemoteExec source)
		{
			_start = source._start.Shadow;
			_done = source._done.Shadow;
		}

		public void CopyShadowToPlain(HansPlc.IShadowfbSimpleRemoteExec source)
		{
			this.CopyShadowToPlain((HansPlc.fbSimpleRemoteExec)source);
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainfbSimpleRemoteExec()
		{
		}
	}
}