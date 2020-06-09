using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "InfluxData", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class InfluxData : Vortex.Connector.IVortexObject, IInfluxData, IShadowInfluxData, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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
		Vortex.Connector.ValueTypes.OnlinerUDInt _CycleCount;
		public Vortex.Connector.ValueTypes.OnlinerUDInt CycleCount
		{
			get
			{
				return _CycleCount;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IInfluxData.CycleCount
		{
			get
			{
				return CycleCount;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowInfluxData.CycleCount
		{
			get
			{
				return CycleCount;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerUDInt _CycleTime;
		public Vortex.Connector.ValueTypes.OnlinerUDInt CycleTime
		{
			get
			{
				return _CycleTime;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IInfluxData.CycleTime
		{
			get
			{
				return CycleTime;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowInfluxData.CycleTime
		{
			get
			{
				return CycleTime;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerUDInt _LastExecTime;
		public Vortex.Connector.ValueTypes.OnlinerUDInt LastExecTime
		{
			get
			{
				return _LastExecTime;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IInfluxData.LastExecTime
		{
			get
			{
				return LastExecTime;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowInfluxData.LastExecTime
		{
			get
			{
				return LastExecTime;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerUDInt _Minimum;
		public Vortex.Connector.ValueTypes.OnlinerUDInt Minimum
		{
			get
			{
				return _Minimum;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IInfluxData.Minimum
		{
			get
			{
				return Minimum;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowInfluxData.Minimum
		{
			get
			{
				return Minimum;
			}
		}

		Vortex.Connector.ValueTypes.OnlinerUDInt _Maximum;
		public Vortex.Connector.ValueTypes.OnlinerUDInt Maximum
		{
			get
			{
				return _Maximum;
			}
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IInfluxData.Maximum
		{
			get
			{
				return Maximum;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowInfluxData.Maximum
		{
			get
			{
				return Maximum;
			}
		}

		public void LazyOnlineToShadow()
		{
			CycleCount.Shadow = CycleCount.LastValue;
			CycleTime.Shadow = CycleTime.LastValue;
			LastExecTime.Shadow = LastExecTime.LastValue;
			Minimum.Shadow = Minimum.LastValue;
			Maximum.Shadow = Maximum.LastValue;
		}

		public void LazyShadowToOnline()
		{
			CycleCount.Cyclic = CycleCount.Shadow;
			CycleTime.Cyclic = CycleTime.Shadow;
			LastExecTime.Cyclic = LastExecTime.Shadow;
			Minimum.Cyclic = Minimum.Shadow;
			Maximum.Cyclic = Maximum.Shadow;
		}

		public PlainInfluxData CreatePlainerType()
		{
			var cloned = new PlainInfluxData();
			return cloned;
		}

		protected PlainInfluxData CreatePlainerType(PlainInfluxData cloned)
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

		public void FlushPlainToOnline(HansPlc.PlainInfluxData source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainInfluxData source)
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

		public void FlushOnlineToPlain(HansPlc.PlainInfluxData source)
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

		public InfluxData(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
		{
			this.@SymbolTail = symbolTail;
			this.@Connector = parent.GetConnector();
			this.@ValueTags = new System.Collections.Generic.List<Vortex.Connector.IValueTag>();
			this.@Children = new System.Collections.Generic.List<Vortex.Connector.IVortexObject>();
			this.@Parent = parent;
			_humanReadable = Vortex.Connector.IConnector.CreateSymbol(parent.HumanReadable, readableTail);
			PexPreConstructor(parent, readableTail, symbolTail);
			Symbol = Vortex.Connector.IConnector.CreateSymbol(parent.Symbol, symbolTail);
			_CycleCount = @Connector.Online.Adapter.CreateUDINT(this, "", "CycleCount");
			_CycleTime = @Connector.Online.Adapter.CreateUDINT(this, "", "CycleTime");
			_LastExecTime = @Connector.Online.Adapter.CreateUDINT(this, "", "LastExecTime");
			_Minimum = @Connector.Online.Adapter.CreateUDINT(this, "", "Minimum");
			_Maximum = @Connector.Online.Adapter.CreateUDINT(this, "", "Maximum");
			AttributeName = "";
			PexConstructor(parent, readableTail, symbolTail);
			parent.AddChild(this);
		}

		public InfluxData()
		{
			PexPreConstructorParameterless();
			_CycleCount = Vortex.Connector.IConnectorFactory.CreateUDINT();
			_CycleTime = Vortex.Connector.IConnectorFactory.CreateUDINT();
			_LastExecTime = Vortex.Connector.IConnectorFactory.CreateUDINT();
			_Minimum = Vortex.Connector.IConnectorFactory.CreateUDINT();
			_Maximum = Vortex.Connector.IConnectorFactory.CreateUDINT();
			AttributeName = "";
			PexConstructorParameterless();
		}

		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Advanced)]
		protected abstract class PlcInfluxData
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcInfluxData()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IInfluxData : Vortex.Connector.IVortexOnlineObject
	{
		Vortex.Connector.ValueTypes.Online.IOnlineUDInt CycleCount
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt CycleTime
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt LastExecTime
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt Minimum
		{
			get;
		}

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt Maximum
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainInfluxData CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainInfluxData source);
		void FlushOnlineToPlain(HansPlc.PlainInfluxData source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowInfluxData : Vortex.Connector.IVortexShadowObject
	{
		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt CycleCount
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt CycleTime
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt LastExecTime
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt Minimum
		{
			get;
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt Maximum
		{
			get;
		}

		System.String AttributeName
		{
			get;
		}

		HansPlc.PlainInfluxData CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainInfluxData source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainInfluxData : Vortex.Connector.IPlain
	{
		System.UInt32 _CycleCount;
		public System.UInt32 CycleCount
		{
			get
			{
				return _CycleCount;
			}

			set
			{
				_CycleCount = value;
			}
		}

		System.UInt32 _CycleTime;
		public System.UInt32 CycleTime
		{
			get
			{
				return _CycleTime;
			}

			set
			{
				_CycleTime = value;
			}
		}

		System.UInt32 _LastExecTime;
		public System.UInt32 LastExecTime
		{
			get
			{
				return _LastExecTime;
			}

			set
			{
				_LastExecTime = value;
			}
		}

		System.UInt32 _Minimum;
		public System.UInt32 Minimum
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

		System.UInt32 _Maximum;
		public System.UInt32 Maximum
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

		public void CopyPlainToCyclic(HansPlc.InfluxData target)
		{
			target.CycleCount.Cyclic = CycleCount;
			target.CycleTime.Cyclic = CycleTime;
			target.LastExecTime.Cyclic = LastExecTime;
			target.Minimum.Cyclic = Minimum;
			target.Maximum.Cyclic = Maximum;
		}

		public void CopyPlainToCyclic(HansPlc.IInfluxData target)
		{
			this.CopyPlainToCyclic((HansPlc.InfluxData)target);
		}

		public void CopyPlainToShadow(HansPlc.InfluxData target)
		{
			target.CycleCount.Shadow = CycleCount;
			target.CycleTime.Shadow = CycleTime;
			target.LastExecTime.Shadow = LastExecTime;
			target.Minimum.Shadow = Minimum;
			target.Maximum.Shadow = Maximum;
		}

		public void CopyPlainToShadow(HansPlc.IShadowInfluxData target)
		{
			this.CopyPlainToShadow((HansPlc.InfluxData)target);
		}

		public void CopyCyclicToPlain(HansPlc.InfluxData source)
		{
			CycleCount = source.CycleCount.LastValue;
			CycleTime = source.CycleTime.LastValue;
			LastExecTime = source.LastExecTime.LastValue;
			Minimum = source.Minimum.LastValue;
			Maximum = source.Maximum.LastValue;
		}

		public void CopyCyclicToPlain(HansPlc.IInfluxData source)
		{
			this.CopyCyclicToPlain((HansPlc.InfluxData)source);
		}

		public void CopyShadowToPlain(HansPlc.InfluxData source)
		{
			CycleCount = source.CycleCount.Shadow;
			CycleTime = source.CycleTime.Shadow;
			LastExecTime = source.LastExecTime.Shadow;
			Minimum = source.Minimum.Shadow;
			Maximum = source.Maximum.Shadow;
		}

		public void CopyShadowToPlain(HansPlc.IShadowInfluxData source)
		{
			this.CopyShadowToPlain((HansPlc.InfluxData)source);
		}

		public PlainInfluxData()
		{
		}
	}
}