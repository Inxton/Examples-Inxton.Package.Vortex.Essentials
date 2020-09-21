using System;
using Vortex.Connector;
using Vortex.Connector.Peripheries;
using Vortex.Connector.Attributes;
using Vortex.Connector.ValueTypes;
using Vortex.Connector.Identity;

namespace HansPlc
{
	[Vortex.Connector.Attributes.TypeMetaDescriptorAttribute("{attribute addProperty Name \"\" }", "structMongoData", "HansPlc", TypeComplexityEnum.Complex)]
	public partial class structMongoData : Vortex.Connector.IVortexObject, IstructMongoData, IShadowstructMongoData, Vortex.Connector.IVortexOnlineObject, Vortex.Connector.IVortexShadowObject
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

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IstructMongoData.CycleCount
		{
			get
			{
				return CycleCount;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowstructMongoData.CycleCount
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

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IstructMongoData.CycleTime
		{
			get
			{
				return CycleTime;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowstructMongoData.CycleTime
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

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IstructMongoData.LastExecTime
		{
			get
			{
				return LastExecTime;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowstructMongoData.LastExecTime
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

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IstructMongoData.Minimum
		{
			get
			{
				return Minimum;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowstructMongoData.Minimum
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

		Vortex.Connector.ValueTypes.Online.IOnlineUDInt IstructMongoData.Maximum
		{
			get
			{
				return Maximum;
			}
		}

		Vortex.Connector.ValueTypes.Shadows.IShadowUDInt IShadowstructMongoData.Maximum
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

		public PlainstructMongoData CreatePlainerType()
		{
			var cloned = new PlainstructMongoData();
			return cloned;
		}

		protected PlainstructMongoData CreatePlainerType(PlainstructMongoData cloned)
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

		public void FlushPlainToOnline(HansPlc.PlainstructMongoData source)
		{
			source.CopyPlainToCyclic(this);
			this.Write();
		}

		public void CopyPlainToShadow(HansPlc.PlainstructMongoData source)
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

		public void FlushOnlineToPlain(HansPlc.PlainstructMongoData source)
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

		public structMongoData(Vortex.Connector.IVortexObject parent, string readableTail, string symbolTail)
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

		public structMongoData()
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
		protected abstract class PlcstructMongoData
		{
			///<summary>Prevents creating instance of this class via public constructor</summary><exclude/>
			protected PlcstructMongoData()
			{
			}
		}
	}

	
            /// <summary>
            /// This is onliner interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IstructMongoData : Vortex.Connector.IVortexOnlineObject
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

		HansPlc.PlainstructMongoData CreatePlainerType();
		void FlushOnlineToShadow();
		void FlushPlainToOnline(HansPlc.PlainstructMongoData source);
		void FlushOnlineToPlain(HansPlc.PlainstructMongoData source);
	}

	
            /// <summary>
            /// This is shadow interface for its respective class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial interface IShadowstructMongoData : Vortex.Connector.IVortexShadowObject
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

		HansPlc.PlainstructMongoData CreatePlainerType();
		void FlushShadowToOnline();
		void CopyPlainToShadow(HansPlc.PlainstructMongoData source);
	}

	
            /// <summary>
            /// This is POCO object for its respective onliner class. For documentation of this type see the onliner class.
            /// </summary>
            /// <exclude />
	public partial class PlainstructMongoData : System.ComponentModel.INotifyPropertyChanged, Vortex.Connector.IPlain
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
				if (_CycleCount != value)
				{
					_CycleCount = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(CycleCount)));
				}
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
				if (_CycleTime != value)
				{
					_CycleTime = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(CycleTime)));
				}
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
				if (_LastExecTime != value)
				{
					_LastExecTime = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(LastExecTime)));
				}
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
				if (_Minimum != value)
				{
					_Minimum = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Minimum)));
				}
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
				if (_Maximum != value)
				{
					_Maximum = value;
					PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(nameof(Maximum)));
				}
			}
		}

		public void CopyPlainToCyclic(HansPlc.structMongoData target)
		{
			target.CycleCount.Cyclic = CycleCount;
			target.CycleTime.Cyclic = CycleTime;
			target.LastExecTime.Cyclic = LastExecTime;
			target.Minimum.Cyclic = Minimum;
			target.Maximum.Cyclic = Maximum;
		}

		public void CopyPlainToCyclic(HansPlc.IstructMongoData target)
		{
			this.CopyPlainToCyclic((HansPlc.structMongoData)target);
		}

		public void CopyPlainToShadow(HansPlc.structMongoData target)
		{
			target.CycleCount.Shadow = CycleCount;
			target.CycleTime.Shadow = CycleTime;
			target.LastExecTime.Shadow = LastExecTime;
			target.Minimum.Shadow = Minimum;
			target.Maximum.Shadow = Maximum;
		}

		public void CopyPlainToShadow(HansPlc.IShadowstructMongoData target)
		{
			this.CopyPlainToShadow((HansPlc.structMongoData)target);
		}

		public void CopyCyclicToPlain(HansPlc.structMongoData source)
		{
			CycleCount = source.CycleCount.LastValue;
			CycleTime = source.CycleTime.LastValue;
			LastExecTime = source.LastExecTime.LastValue;
			Minimum = source.Minimum.LastValue;
			Maximum = source.Maximum.LastValue;
		}

		public void CopyCyclicToPlain(HansPlc.IstructMongoData source)
		{
			this.CopyCyclicToPlain((HansPlc.structMongoData)source);
		}

		public void CopyShadowToPlain(HansPlc.structMongoData source)
		{
			CycleCount = source.CycleCount.Shadow;
			CycleTime = source.CycleTime.Shadow;
			LastExecTime = source.LastExecTime.Shadow;
			Minimum = source.Minimum.Shadow;
			Maximum = source.Maximum.Shadow;
		}

		public void CopyShadowToPlain(HansPlc.IShadowstructMongoData source)
		{
			this.CopyShadowToPlain((HansPlc.structMongoData)source);
		}

		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
		public PlainstructMongoData()
		{
		}
	}
}