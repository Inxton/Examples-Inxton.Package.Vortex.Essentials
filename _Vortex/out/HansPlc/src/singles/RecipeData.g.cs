using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "RecipeData", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class RecipeData : Vortex.Connector.IVortexObject, IRecipeData, IShadowRecipeData, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		stRecipe __recipe;
		public stRecipe _recipe
		{
			get
			{
				return __recipe;
			}
		}

		IstRecipe IRecipeData._recipe
		{
			get
			{
				return _recipe;
			}
		}

		IShadowstRecipe IShadowRecipeData._recipe
		{
			get
			{
				return _recipe;
			}
		}

		public void LazyOnlineToShadow()
		{
			_recipe.LazyOnlineToShadow();
		}

		public void LazyShadowToOnline()
		{
			_recipe.LazyShadowToOnline();
		}

		public PlainRecipeData CreatePlainerType()
		{
			var cloned = new PlainRecipeData();
			cloned._recipe = _recipe.CreatePlainerType();
			return cloned;
		}

		protected PlainRecipeData CreatePlainerType(PlainRecipeData cloned)
		{
			cloned._recipe = _recipe.CreatePlainerType();
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

		public void FlushPlainToOnline(HansPlc.PlainRecipeData source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainRecipeData source)
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

		public void FlushOnlineToPlain(HansPlc.PlainRecipeData source)
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

		public RecipeData(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			__recipe = new stRecipe(this, "", "_recipe");
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public RecipeData()
		{
			PexPreConstructorParameterless();
			__recipe = new stRecipe();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcRecipeData
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcRecipeData()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IRecipeData : Vortex.Connector.IVortexOnlineObject
	{
		IstRecipe _recipe
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainRecipeData CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainRecipeData source);
		void FlushOnlineToPlain(HansPlc.PlainRecipeData source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowRecipeData : Vortex.Connector.IVortexShadowObject
	{
		IShadowstRecipe _recipe
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainRecipeData CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainRecipeData source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainRecipeData : Vortex.Connector.IPlain
	{
		PlainstRecipe __recipe;
		public PlainstRecipe _recipe
		{
			get
			{
				return __recipe;
			}

			set
			{
				__recipe = value;
			}
		}

		public void CopyPlainToCyclic(HansPlc.RecipeData target)
		{
			_recipe.CopyPlainToCyclic(target._recipe);
		}

		public void CopyPlainToCyclic(HansPlc.IRecipeData target)
		{
			this.CopyPlainToCyclic((HansPlc.RecipeData)target);
		}

		public void CopyPlainToShadow(HansPlc.RecipeData target)
		{
			_recipe.CopyPlainToShadow(target._recipe);
		}

		public void CopyPlainToShadow(HansPlc.IShadowRecipeData target)
		{
			this.CopyPlainToShadow((HansPlc.RecipeData)target);
		}

		public void CopyCyclicToPlain(HansPlc.RecipeData source)
		{
			_recipe.CopyCyclicToPlain(source._recipe);
		}

		public void CopyCyclicToPlain(HansPlc.IRecipeData source)
		{
			this.CopyCyclicToPlain((HansPlc.RecipeData)source);
		}

		public void CopyShadowToPlain(HansPlc.RecipeData source)
		{
			_recipe.CopyShadowToPlain(source._recipe);
		}

		public void CopyShadowToPlain(HansPlc.IShadowRecipeData source)
		{
			this.CopyShadowToPlain((HansPlc.RecipeData)source);
		}

		public PlainRecipeData()
		{
			__recipe = new PlainstRecipe();
		}
	}
}