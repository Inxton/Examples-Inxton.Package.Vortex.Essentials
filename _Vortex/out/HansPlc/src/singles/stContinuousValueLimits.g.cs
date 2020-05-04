using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Container(Layout.Wrap), Group(Layout.GroupBox)]
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "stContinuousValueLimits", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class stContinuousValueLimits : Vortex.Connector.IVortexObject, IstContinuousValueLimits, IShadowstContinuousValueLimits, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerReal _Minimum;
		public Vortex.Connector.ValueTypes.OnlinerReal Minimum
		{
			get
			{
				return _Minimum;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal IstContinuousValueLimits.Minimum
		{
			get
			{
				return Minimum;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal IShadowstContinuousValueLimits.Minimum
		{
			get
			{
				return Minimum;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerReal _Acquired;
		[RenderIgnore("Control", "ShadowControl")]
		public Vortex.Connector.ValueTypes.OnlinerReal Acquired
		{
			get
			{
				return _Acquired;
			}
		}

		[RenderIgnore("Control", "ShadowControl")]
		Vortex.Connector.ValueTypes.Online.IOnlineReal IstContinuousValueLimits.Acquired
		{
			get
			{
				return Acquired;
			}
		}

		[RenderIgnore("Control", "ShadowControl")]
		Vortex.Connector.ValueTypes.Shadows.IShadowReal IShadowstContinuousValueLimits.Acquired
		{
			get
			{
				return Acquired;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerReal _Maximum;
		public Vortex.Connector.ValueTypes.OnlinerReal Maximum
		{
			get
			{
				return _Maximum;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal IstContinuousValueLimits.Maximum
		{
			get
			{
				return Maximum;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal IShadowstContinuousValueLimits.Maximum
		{
			get
			{
				return Maximum;
			}
		}

		public void LazyOnlineToShadow()
		{
			Minimum.Shadow = Minimum.LastValue;
			Acquired.Shadow = Acquired.LastValue;
			Maximum.Shadow = Maximum.LastValue;
		}

		public void LazyShadowToOnline()
		{
			Minimum.Cyclic = Minimum.Shadow;
			Acquired.Cyclic = Acquired.Shadow;
			Maximum.Cyclic = Maximum.Shadow;
		}

		public PlainstContinuousValueLimits CreatePlainerType()
		{
			var cloned = new PlainstContinuousValueLimits();
			return cloned;
		}

		protected PlainstContinuousValueLimits CreatePlainerType(PlainstContinuousValueLimits cloned)
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

		public void FlushPlainToOnline(HansPlc.PlainstContinuousValueLimits source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainstContinuousValueLimits source)
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

		public void FlushOnlineToPlain(HansPlc.PlainstContinuousValueLimits source)
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

		public stContinuousValueLimits(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			_Minimum = @Connector.Online.Adapter.CreateREAL(this, "<#Min#>", "Minimum");
			Minimum.AttributeName = "<#Min#>";
			_Acquired = @Connector.Online.Adapter.CreateREAL(this, "<#Acquired#>", "Acquired");
			Acquired.AttributeName = "<#Acquired#>";
			_Maximum = @Connector.Online.Adapter.CreateREAL(this, "<#Max#>", "Maximum");
			Maximum.AttributeName = "<#Max#>";
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public stContinuousValueLimits()
		{
			PexPreConstructorParameterless();
			_Minimum = Vortex.Connector.IConnectorFactory.CreateREAL();
			Minimum.AttributeName = "<#Min#>";
			_Acquired = Vortex.Connector.IConnectorFactory.CreateREAL();
			Acquired.AttributeName = "<#Acquired#>";
			_Maximum = Vortex.Connector.IConnectorFactory.CreateREAL();
			Maximum.AttributeName = "<#Max#>";
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcstContinuousValueLimits
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcstContinuousValueLimits()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IstContinuousValueLimits : Vortex.Connector.IVortexOnlineObject
	{
		Vortex.Connector.ValueTypes.Online.IOnlineReal Minimum
		{
			get;
		}

		[RenderIgnore("Control", "ShadowControl")]
		Vortex.Connector.ValueTypes.Online.IOnlineReal Acquired
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineReal Maximum
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainstContinuousValueLimits CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainstContinuousValueLimits source);
		void FlushOnlineToPlain(HansPlc.PlainstContinuousValueLimits source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowstContinuousValueLimits : Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.Shadows.IShadowReal Minimum
		{
			get;
		}

		[RenderIgnore("Control", "ShadowControl")]
		Vortex.Connector.ValueTypes.Shadows.IShadowReal Acquired
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowReal Maximum
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainstContinuousValueLimits CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainstContinuousValueLimits source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainstContinuousValueLimits : Vortex.Connector.IPlain
	{
		System.Single _Minimum;
		public System.Single Minimum
		{
			get
			{
				return _Minimum;
			}

			set
			{
				_Minimum = value;
			}
		}

		System.Single _Acquired;
		[RenderIgnore("Control", "ShadowControl")]
		public System.Single Acquired
		{
			get
			{
				return _Acquired;
			}

			set
			{
				_Acquired = value;
			}
		}

		System.Single _Maximum;
		public System.Single Maximum
		{
			get
			{
				return _Maximum;
			}

			set
			{
				_Maximum = value;
			}
		}

		public void CopyPlainToCyclic(HansPlc.stContinuousValueLimits target)
		{
			target.Minimum.Cyclic = Minimum;
			target.Acquired.Cyclic = Acquired;
			target.Maximum.Cyclic = Maximum;
		}

		public void CopyPlainToCyclic(HansPlc.IstContinuousValueLimits target)
		{
			this.CopyPlainToCyclic((HansPlc.stContinuousValueLimits)target);
		}

		public void CopyPlainToShadow(HansPlc.stContinuousValueLimits target)
		{
			target.Minimum.Shadow = Minimum;
			target.Acquired.Shadow = Acquired;
			target.Maximum.Shadow = Maximum;
		}

		public void CopyPlainToShadow(HansPlc.IShadowstContinuousValueLimits target)
		{
			this.CopyPlainToShadow((HansPlc.stContinuousValueLimits)target);
		}

		public void CopyCyclicToPlain(HansPlc.stContinuousValueLimits source)
		{
			Minimum = source.Minimum.LastValue;
			Acquired = source.Acquired.LastValue;
			Maximum = source.Maximum.LastValue;
		}

		public void CopyCyclicToPlain(HansPlc.IstContinuousValueLimits source)
		{
			this.CopyCyclicToPlain((HansPlc.stContinuousValueLimits)source);
		}

		public void CopyShadowToPlain(HansPlc.stContinuousValueLimits source)
		{
			Minimum = source.Minimum.Shadow;
			Acquired = source.Acquired.Shadow;
			Maximum = source.Maximum.Shadow;
		}

		public void CopyShadowToPlain(HansPlc.IShadowstContinuousValueLimits source)
		{
			this.CopyShadowToPlain((HansPlc.stContinuousValueLimits)source);
		}

		public PlainstContinuousValueLimits()
		{
		}
	}
}