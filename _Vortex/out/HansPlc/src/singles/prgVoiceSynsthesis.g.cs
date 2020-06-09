using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "prgVoiceSynsthesis", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class prgVoiceSynsthesis : Vortex.Connector.IVortexObject, IprgVoiceSynsthesis, IShadowprgVoiceSynsthesis, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		public void LazyOnlineToShadow()
		{
		}

		public void LazyShadowToOnline()
		{
		}

		public PlainprgVoiceSynsthesis CreatePlainerType()
		{
			var cloned = new PlainprgVoiceSynsthesis();
			return cloned;
		}

		protected PlainprgVoiceSynsthesis CreatePlainerType(PlainprgVoiceSynsthesis cloned)
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

		public void FlushPlainToOnline(HansPlc.PlainprgVoiceSynsthesis source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainprgVoiceSynsthesis source)
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

		public void FlushOnlineToPlain(HansPlc.PlainprgVoiceSynsthesis source)
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

		public prgVoiceSynsthesis(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public prgVoiceSynsthesis()
		{
			PexPreConstructorParameterless();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcprgVoiceSynsthesis
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcprgVoiceSynsthesis()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IprgVoiceSynsthesis : Vortex.Connector.IVortexOnlineObject
	{
		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgVoiceSynsthesis CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainprgVoiceSynsthesis source);
		void FlushOnlineToPlain(HansPlc.PlainprgVoiceSynsthesis source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowprgVoiceSynsthesis : Vortex.Connector.IVortexShadowObject
	{
		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainprgVoiceSynsthesis CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainprgVoiceSynsthesis source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainprgVoiceSynsthesis : Vortex.Connector.IPlain
	{
		public void CopyPlainToCyclic(HansPlc.prgVoiceSynsthesis target)
		{
		}

		public void CopyPlainToCyclic(HansPlc.IprgVoiceSynsthesis target)
		{
			this.CopyPlainToCyclic((HansPlc.prgVoiceSynsthesis)target);
		}

		public void CopyPlainToShadow(HansPlc.prgVoiceSynsthesis target)
		{
		}

		public void CopyPlainToShadow(HansPlc.IShadowprgVoiceSynsthesis target)
		{
			this.CopyPlainToShadow((HansPlc.prgVoiceSynsthesis)target);
		}

		public void CopyCyclicToPlain(HansPlc.prgVoiceSynsthesis source)
		{
		}

		public void CopyCyclicToPlain(HansPlc.IprgVoiceSynsthesis source)
		{
			this.CopyCyclicToPlain((HansPlc.prgVoiceSynsthesis)source);
		}

		public void CopyShadowToPlain(HansPlc.prgVoiceSynsthesis source)
		{
		}

		public void CopyShadowToPlain(HansPlc.IShadowprgVoiceSynsthesis source)
		{
			this.CopyShadowToPlain((HansPlc.prgVoiceSynsthesis)source);
		}

		public PlainprgVoiceSynsthesis()
		{
		}
	}
}