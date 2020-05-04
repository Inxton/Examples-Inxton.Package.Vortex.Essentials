using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "stRecipe", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class stRecipe : Vortex.Connector.IVortexObject, IstRecipe, IShadowstRecipe, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerString __recipeName;
		public Vortex.Connector.ValueTypes.OnlinerString _recipeName
		{
			get
			{
				return __recipeName;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString IstRecipe._recipeName
		{
			get
			{
				return _recipeName;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString IShadowstRecipe._recipeName
		{
			get
			{
				return _recipeName;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerString __description;
		public Vortex.Connector.ValueTypes.OnlinerString _description
		{
			get
			{
				return __description;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString IstRecipe._description
		{
			get
			{
				return _description;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString IShadowstRecipe._description
		{
			get
			{
				return _description;
			}
		}

		stContinuousValueLimits __lenght;
		public stContinuousValueLimits _lenght
		{
			get
			{
				return __lenght;
			}
		}

		IstContinuousValueLimits IstRecipe._lenght
		{
			get
			{
				return _lenght;
			}
		}

		IShadowstContinuousValueLimits IShadowstRecipe._lenght
		{
			get
			{
				return _lenght;
			}
		}

		stContinuousValueLimits __height;
		public stContinuousValueLimits _height
		{
			get
			{
				return __height;
			}
		}

		IstContinuousValueLimits IstRecipe._height
		{
			get
			{
				return _height;
			}
		}

		IShadowstContinuousValueLimits IShadowstRecipe._height
		{
			get
			{
				return _height;
			}
		}

		stContinuousValueLimits __thikness;
		public stContinuousValueLimits _thikness
		{
			get
			{
				return __thikness;
			}
		}

		IstContinuousValueLimits IstRecipe._thikness
		{
			get
			{
				return _thikness;
			}
		}

		IShadowstContinuousValueLimits IShadowstRecipe._thikness
		{
			get
			{
				return _thikness;
			}
		}

		public void LazyOnlineToShadow()
		{
			_recipeName.Shadow = _recipeName.LastValue;
			_description.Shadow = _description.LastValue;
			_lenght.LazyOnlineToShadow();
			_height.LazyOnlineToShadow();
			_thikness.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			_recipeName.Cyclic = _recipeName.Shadow;
			_description.Cyclic = _description.Shadow;
			_lenght.LazyShadowToOnline();
			_height.LazyShadowToOnline();
			_thikness.LazyShadowToOnline();
		}

		public PlainstRecipe CreatePlainerType()
		{
			var cloned = new PlainstRecipe();
			cloned._lenght = _lenght.CreatePlainerType();
			cloned._height = _height.CreatePlainerType();
			cloned._thikness = _thikness.CreatePlainerType();
			return cloned;
		}

		protected PlainstRecipe CreatePlainerType(PlainstRecipe cloned)
		{
			cloned._lenght = _lenght.CreatePlainerType();
			cloned._height = _height.CreatePlainerType();
			cloned._thikness = _thikness.CreatePlainerType();
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

		public void FlushPlainToOnline(HansPlc.PlainstRecipe source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainstRecipe source)
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

		public void FlushOnlineToPlain(HansPlc.PlainstRecipe source)
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

		public stRecipe(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			__recipeName = @Connector.Online.Adapter.CreateSTRING(this, "<#Recipe name#>", "_recipeName");
			_recipeName.AttributeName = "<#Recipe name#>";
			__description = @Connector.Online.Adapter.CreateSTRING(this, "<#Description#>", "_description");
			_description.AttributeName = "<#Description#>";
			__lenght = new stContinuousValueLimits(this, "<#Lenght#> [mm]", "_lenght");
			__lenght.AttributeName = "<#Lenght#> [mm]";
			__height = new stContinuousValueLimits(this, "<#Height#> [mm]", "_height");
			__height.AttributeName = "<#Height#> [mm]";
			__thikness = new stContinuousValueLimits(this, "<#Thickness#> [mm]", "_thikness");
			__thikness.AttributeName = "<#Thickness#> [mm]";
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public stRecipe()
		{
			PexPreConstructorParameterless();
			__recipeName = Vortex.Connector.IConnectorFactory.CreateSTRING();
			_recipeName.AttributeName = "<#Recipe name#>";
			__description = Vortex.Connector.IConnectorFactory.CreateSTRING();
			_description.AttributeName = "<#Description#>";
			__lenght = new stContinuousValueLimits();
			__lenght.AttributeName = "<#Lenght#> [mm]";
			__height = new stContinuousValueLimits();
			__height.AttributeName = "<#Height#> [mm]";
			__thikness = new stContinuousValueLimits();
			__thikness.AttributeName = "<#Thickness#> [mm]";
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcstRecipe
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcstRecipe()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IstRecipe : Vortex.Connector.IVortexOnlineObject
	{
		Vortex.Connector.ValueTypes.Online.IOnlineString _recipeName
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineString _description
		{
			get;
		}

		IstContinuousValueLimits _lenght
		{
			get;
		}

		IstContinuousValueLimits _height
		{
			get;
		}

		IstContinuousValueLimits _thikness
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainstRecipe CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainstRecipe source);
		void FlushOnlineToPlain(HansPlc.PlainstRecipe source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowstRecipe : Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.Shadows.IShadowString _recipeName
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowString _description
		{
			get;
		}

		IShadowstContinuousValueLimits _lenght
		{
			get;
		}

		IShadowstContinuousValueLimits _height
		{
			get;
		}

		IShadowstContinuousValueLimits _thikness
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainstRecipe CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainstRecipe source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainstRecipe : Vortex.Connector.IPlain
	{
		System.String __recipeName;
		public System.String _recipeName
		{
			get
			{
				return __recipeName;
			}

			set
			{
				__recipeName = value;
			}
		}

		System.String __description;
		public System.String _description
		{
			get
			{
				return __description;
			}

			set
			{
				__description = value;
			}
		}

		PlainstContinuousValueLimits __lenght;
		public PlainstContinuousValueLimits _lenght
		{
			get
			{
				return __lenght;
			}

			set
			{
				__lenght = value;
			}
		}

		PlainstContinuousValueLimits __height;
		public PlainstContinuousValueLimits _height
		{
			get
			{
				return __height;
			}

			set
			{
				__height = value;
			}
		}

		PlainstContinuousValueLimits __thikness;
		public PlainstContinuousValueLimits _thikness
		{
			get
			{
				return __thikness;
			}

			set
			{
				__thikness = value;
			}
		}

		public void CopyPlainToCyclic(HansPlc.stRecipe target)
		{
			target._recipeName.Cyclic = _recipeName;
			target._description.Cyclic = _description;
			_lenght.CopyPlainToCyclic(target._lenght);
			_height.CopyPlainToCyclic(target._height);
			_thikness.CopyPlainToCyclic(target._thikness);
		}

		public void CopyPlainToCyclic(HansPlc.IstRecipe target)
		{
			this.CopyPlainToCyclic((HansPlc.stRecipe)target);
		}

		public void CopyPlainToShadow(HansPlc.stRecipe target)
		{
			target._recipeName.Shadow = _recipeName;
			target._description.Shadow = _description;
			_lenght.CopyPlainToShadow(target._lenght);
			_height.CopyPlainToShadow(target._height);
			_thikness.CopyPlainToShadow(target._thikness);
		}

		public void CopyPlainToShadow(HansPlc.IShadowstRecipe target)
		{
			this.CopyPlainToShadow((HansPlc.stRecipe)target);
		}

		public void CopyCyclicToPlain(HansPlc.stRecipe source)
		{
			_recipeName = source._recipeName.LastValue;
			_description = source._description.LastValue;
			_lenght.CopyCyclicToPlain(source._lenght);
			_height.CopyCyclicToPlain(source._height);
			_thikness.CopyCyclicToPlain(source._thikness);
		}

		public void CopyCyclicToPlain(HansPlc.IstRecipe source)
		{
			this.CopyCyclicToPlain((HansPlc.stRecipe)source);
		}

		public void CopyShadowToPlain(HansPlc.stRecipe source)
		{
			_recipeName = source._recipeName.Shadow;
			_description = source._description.Shadow;
			_lenght.CopyShadowToPlain(source._lenght);
			_height.CopyShadowToPlain(source._height);
			_thikness.CopyShadowToPlain(source._thikness);
		}

		public void CopyShadowToPlain(HansPlc.IShadowstRecipe source)
		{
			this.CopyShadowToPlain((HansPlc.stRecipe)source);
		}

		public PlainstRecipe()
		{
			__lenght = new PlainstContinuousValueLimits();
			__height = new PlainstContinuousValueLimits();
			__thikness = new PlainstContinuousValueLimits();
		}
	}
}