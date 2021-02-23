using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
#pragma warning disable SA1402, CS1591, CS0108, CS0067
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "fbSpeech", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class fbSpeech : fbSimpleRemoteExec, Vortex.Connector.IVortexObject, IfbSpeech, IShadowfbSpeech, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
	{
		public new void LazyOnlineToShadow()
		{
			base.LazyOnlineToShadow();
		}

		public new void LazyShadowToOnline()
		{
			base.LazyShadowToOnline();
		}

		public new PlainfbSpeech CreatePlainerType()
		{
			var cloned = new PlainfbSpeech();
			base.CreatePlainerType(cloned);
			return cloned;
		}

		protected PlainfbSpeech CreatePlainerType(PlainfbSpeech cloned)
		{
			base.CreatePlainerType(cloned);
			return cloned;
		}

		partial void PexPreConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexPreConstructorParameterless();
		partial void PexConstructor(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail);
		partial void PexConstructorParameterless();
		public void FlushPlainToOnline(HansPlc.PlainfbSpeech source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainfbSpeech source)
		{
			source.CopyPlainToShadow(this);
		}

		public new void FlushShadowToOnline()
		{
			this.LazyShadowToOnline();
			this.Write();
		}

		public new void FlushOnlineToShadow()
		{
			this.Read();
			this.LazyOnlineToShadow();
		}

		public void FlushOnlineToPlain(HansPlc.PlainfbSpeech source)
		{
			this.Read();
			source.CopyCyclicToPlain(this);
		}

		public fbSpeech(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail): base (parent, readableTail, symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
		}

		public fbSpeech(): base ()
		{
			PexPreConstructorParameterless();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcfbSpeech : HansPlc.fbSimpleRemoteExec.PlcfbSimpleRemoteExec
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcfbSpeech()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IfbSpeech : Vortex.Connector.IVortexOnlineObject, HansPlc.IfbSimpleRemoteExec
	{
		new HansPlc.PlainfbSpeech CreatePlainerType();
		new void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainfbSpeech source);
		void FlushOnlineToPlain(HansPlc.PlainfbSpeech source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowfbSpeech : Vortex.Connector.IVortexShadowObject, HansPlc.IShadowfbSimpleRemoteExec
	{
		new HansPlc.PlainfbSpeech CreatePlainerType();
		new void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainfbSpeech source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainfbSpeech : HansPlc.PlainfbSimpleRemoteExec
	{
		public void CopyPlainToCyclic(HansPlc.fbSpeech target)
		{
			base.CopyPlainToCyclic(target);
		}

		public void CopyPlainToCyclic(HansPlc.IfbSpeech target)
		{
			this.CopyPlainToCyclic((HansPlc.fbSpeech)target);
		}

		public void CopyPlainToShadow(HansPlc.fbSpeech target)
		{
			base.CopyPlainToShadow(target);
		}

		public void CopyPlainToShadow(HansPlc.IShadowfbSpeech target)
		{
			this.CopyPlainToShadow((HansPlc.fbSpeech)target);
		}

		public void CopyCyclicToPlain(HansPlc.fbSpeech source)
		{
			base.CopyCyclicToPlain(source);
		}

		public void CopyCyclicToPlain(HansPlc.IfbSpeech source)
		{
			this.CopyCyclicToPlain((HansPlc.fbSpeech)source);
		}

		public void CopyShadowToPlain(HansPlc.fbSpeech source)
		{
			base.CopyShadowToPlain(source);
		}

		public void CopyShadowToPlain(HansPlc.IShadowfbSpeech source)
		{
			this.CopyShadowToPlain((HansPlc.fbSpeech)source);
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainfbSpeech()
		{
		}
	}
}