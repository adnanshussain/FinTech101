﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinTech101.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Argaam_Analytics")]
	public partial class ArgaamAnalyticsDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertGlobalEventCategory(GlobalEventCategory instance);
    partial void UpdateGlobalEventCategory(GlobalEventCategory instance);
    partial void DeleteGlobalEventCategory(GlobalEventCategory instance);
    partial void InsertGlobalEvent(GlobalEvent instance);
    partial void UpdateGlobalEvent(GlobalEvent instance);
    partial void DeleteGlobalEvent(GlobalEvent instance);
    #endregion
		
		public ArgaamAnalyticsDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Argaam_AnalyticsConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ArgaamAnalyticsDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArgaamAnalyticsDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArgaamAnalyticsDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ArgaamAnalyticsDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<GlobalEventCategory> GlobalEventCategories
		{
			get
			{
				return this.GetTable<GlobalEventCategory>();
			}
		}
		
		public System.Data.Linq.Table<GlobalEvent> GlobalEvents
		{
			get
			{
				return this.GetTable<GlobalEvent>();
			}
		}
		
		public System.Data.Linq.Table<StockEntity> StockEntities
		{
			get
			{
				return this.GetTable<StockEntity>();
			}
		}
		
		public System.Data.Linq.Table<StockEntityType> StockEntityTypes
		{
			get
			{
				return this.GetTable<StockEntityType>();
			}
		}
		
		public System.Data.Linq.Table<StockEntityPrice> StockEntityPrices
		{
			get
			{
				return this.GetTable<StockEntityPrice>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_Q1_StockEntityWasUpOrDownByPercent")]
		public ISingleResult<SP_Q1_StockEntityWasUpOrDownByPercentResult> SP_Q1_StockEntityWasUpOrDownByPercent([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_stock_entity_id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_stock_entity_type_id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="VarChar(8)")] string p_up_or_down, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Decimal(18,0)")] System.Nullable<decimal> p_percent, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_from_year, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_to_year)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_stock_entity_id, p_stock_entity_type_id, p_up_or_down, p_percent, p_from_year, p_to_year);
			return ((ISingleResult<SP_Q1_StockEntityWasUpOrDownByPercentResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_Q2_StockEntityGoodAndBadDays")]
		public ISingleResult<SP_Q2_StockEntityGoodAndBadDaysResult> SP_Q2_StockEntityGoodAndBadDays([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_type_id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_year)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_se_id, p_se_type_id, p_year);
			return ((ISingleResult<SP_Q2_StockEntityGoodAndBadDaysResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_Q3_StockEntityUpDownMonths")]
		public ISingleResult<SP_Q3_StockEntityUpDownMonthsResult> SP_Q3_StockEntityUpDownMonths([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_from_year, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_to_year, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_type_id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_from_year, p_to_year, p_se_id, p_se_type_id);
			return ((ISingleResult<SP_Q3_StockEntityUpDownMonthsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_Q5_StockEntityTypeUpAndDownMonths")]
		public ISingleResult<SP_Q5_StockEntityTypeUpAndDownMonthsResult> SP_Q5_StockEntityTypeUpAndDownMonths([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_from_year, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_to_year, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_type_id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_from_year, p_to_year, p_se_type_id);
			return ((ISingleResult<SP_Q5_StockEntityTypeUpAndDownMonthsResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SP_Q4_PricesAroundEventDate")]
		public ISingleResult<SP_Q4_PricesAroundEventDateResult> SP_Q4_PricesAroundEventDate([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> p_event_date, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Date")] System.Nullable<System.DateTime> p_event_end_date, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_week_before, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_week_after, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_id, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> p_se_type_id)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), p_event_date, p_event_end_date, p_week_before, p_week_after, p_se_id, p_se_type_id);
			return ((ISingleResult<SP_Q4_PricesAroundEventDateResult>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GlobalEventCategories")]
	public partial class GlobalEventCategory : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _EventCategoryID;
		
		private string _EventCategoryName;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEventCategoryIDChanging(int value);
    partial void OnEventCategoryIDChanged();
    partial void OnEventCategoryNameChanging(string value);
    partial void OnEventCategoryNameChanged();
    #endregion
		
		public GlobalEventCategory()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventCategoryID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int EventCategoryID
		{
			get
			{
				return this._EventCategoryID;
			}
			set
			{
				if ((this._EventCategoryID != value))
				{
					this.OnEventCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._EventCategoryID = value;
					this.SendPropertyChanged("EventCategoryID");
					this.OnEventCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventCategoryName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string EventCategoryName
		{
			get
			{
				return this._EventCategoryName;
			}
			set
			{
				if ((this._EventCategoryName != value))
				{
					this.OnEventCategoryNameChanging(value);
					this.SendPropertyChanging();
					this._EventCategoryName = value;
					this.SendPropertyChanged("EventCategoryName");
					this.OnEventCategoryNameChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GlobalEvents")]
	public partial class GlobalEvent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _GlobalEventID;
		
		private int _EventCategoryID;
		
		private string _EventDesc;
		
		private System.DateTime _StartsOn;
		
		private System.Nullable<System.DateTime> _EndsOn;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGlobalEventIDChanging(int value);
    partial void OnGlobalEventIDChanged();
    partial void OnEventCategoryIDChanging(int value);
    partial void OnEventCategoryIDChanged();
    partial void OnEventDescChanging(string value);
    partial void OnEventDescChanged();
    partial void OnStartsOnChanging(System.DateTime value);
    partial void OnStartsOnChanged();
    partial void OnEndsOnChanging(System.Nullable<System.DateTime> value);
    partial void OnEndsOnChanged();
    #endregion
		
		public GlobalEvent()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GlobalEventID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int GlobalEventID
		{
			get
			{
				return this._GlobalEventID;
			}
			set
			{
				if ((this._GlobalEventID != value))
				{
					this.OnGlobalEventIDChanging(value);
					this.SendPropertyChanging();
					this._GlobalEventID = value;
					this.SendPropertyChanged("GlobalEventID");
					this.OnGlobalEventIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventCategoryID", DbType="Int NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public int EventCategoryID
		{
			get
			{
				return this._EventCategoryID;
			}
			set
			{
				if ((this._EventCategoryID != value))
				{
					this.OnEventCategoryIDChanging(value);
					this.SendPropertyChanging();
					this._EventCategoryID = value;
					this.SendPropertyChanged("EventCategoryID");
					this.OnEventCategoryIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EventDesc", DbType="NVarChar(128) NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string EventDesc
		{
			get
			{
				return this._EventDesc;
			}
			set
			{
				if ((this._EventDesc != value))
				{
					this.OnEventDescChanging(value);
					this.SendPropertyChanging();
					this._EventDesc = value;
					this.SendPropertyChanged("EventDesc");
					this.OnEventDescChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartsOn", DbType="Date NOT NULL", UpdateCheck=UpdateCheck.Never)]
		public System.DateTime StartsOn
		{
			get
			{
				return this._StartsOn;
			}
			set
			{
				if ((this._StartsOn != value))
				{
					this.OnStartsOnChanging(value);
					this.SendPropertyChanging();
					this._StartsOn = value;
					this.SendPropertyChanged("StartsOn");
					this.OnStartsOnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndsOn", DbType="Date", UpdateCheck=UpdateCheck.Never)]
		public System.Nullable<System.DateTime> EndsOn
		{
			get
			{
				return this._EndsOn;
			}
			set
			{
				if ((this._EndsOn != value))
				{
					this.OnEndsOnChanging(value);
					this.SendPropertyChanging();
					this._EndsOn = value;
					this.SendPropertyChanged("EndsOn");
					this.OnEndsOnChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StockEntities")]
	public partial class StockEntity
	{
		
		private int _StockEntityID;
		
		private int _StockEntityTypeID;
		
		private string _NameEn;
		
		private string _NameAr;
		
		private string _ShortNameEn;
		
		private string _ShortNameAr;
		
		private string _Symbol;
		
		public StockEntity()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityID", DbType="Int NOT NULL")]
		public int StockEntityID
		{
			get
			{
				return this._StockEntityID;
			}
			set
			{
				if ((this._StockEntityID != value))
				{
					this._StockEntityID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityTypeID", DbType="Int NOT NULL")]
		public int StockEntityTypeID
		{
			get
			{
				return this._StockEntityTypeID;
			}
			set
			{
				if ((this._StockEntityTypeID != value))
				{
					this._StockEntityTypeID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NameEn", DbType="VarChar(128) NOT NULL", CanBeNull=false)]
		public string NameEn
		{
			get
			{
				return this._NameEn;
			}
			set
			{
				if ((this._NameEn != value))
				{
					this._NameEn = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NameAr", DbType="NVarChar(128)")]
		public string NameAr
		{
			get
			{
				return this._NameAr;
			}
			set
			{
				if ((this._NameAr != value))
				{
					this._NameAr = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortNameEn", DbType="VarChar(50)")]
		public string ShortNameEn
		{
			get
			{
				return this._ShortNameEn;
			}
			set
			{
				if ((this._ShortNameEn != value))
				{
					this._ShortNameEn = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ShortNameAr", DbType="NVarChar(50)")]
		public string ShortNameAr
		{
			get
			{
				return this._ShortNameAr;
			}
			set
			{
				if ((this._ShortNameAr != value))
				{
					this._ShortNameAr = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Symbol", DbType="VarChar(50)")]
		public string Symbol
		{
			get
			{
				return this._Symbol;
			}
			set
			{
				if ((this._Symbol != value))
				{
					this._Symbol = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StockEntityTypes")]
	public partial class StockEntityType
	{
		
		private int _StockEntityTypeID;
		
		private string _StockEntityTypeName;
		
		public StockEntityType()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityTypeID", DbType="Int NOT NULL")]
		public int StockEntityTypeID
		{
			get
			{
				return this._StockEntityTypeID;
			}
			set
			{
				if ((this._StockEntityTypeID != value))
				{
					this._StockEntityTypeID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityTypeName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string StockEntityTypeName
		{
			get
			{
				return this._StockEntityTypeName;
			}
			set
			{
				if ((this._StockEntityTypeName != value))
				{
					this._StockEntityTypeName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StockEntityPrices")]
	public partial class StockEntityPrice
	{
		
		private int _StockEntityID;
		
		private int _StockEntityTypeID;
		
		private System.Nullable<System.DateTime> _ForDate;
		
		private decimal _Open;
		
		private decimal _Close;
		
		private decimal _Min;
		
		private decimal _Max;
		
		private System.Nullable<long> _Volume;
		
		private System.Nullable<long> _Amount;
		
		public StockEntityPrice()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityID", DbType="Int NOT NULL")]
		public int StockEntityID
		{
			get
			{
				return this._StockEntityID;
			}
			set
			{
				if ((this._StockEntityID != value))
				{
					this._StockEntityID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityTypeID", DbType="Int NOT NULL")]
		public int StockEntityTypeID
		{
			get
			{
				return this._StockEntityTypeID;
			}
			set
			{
				if ((this._StockEntityTypeID != value))
				{
					this._StockEntityTypeID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ForDate", DbType="Date")]
		public System.Nullable<System.DateTime> ForDate
		{
			get
			{
				return this._ForDate;
			}
			set
			{
				if ((this._ForDate != value))
				{
					this._ForDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Open]", Storage="_Open", DbType="Decimal(18,2) NOT NULL")]
		public decimal Open
		{
			get
			{
				return this._Open;
			}
			set
			{
				if ((this._Open != value))
				{
					this._Open = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Close]", Storage="_Close", DbType="Decimal(18,2) NOT NULL")]
		public decimal Close
		{
			get
			{
				return this._Close;
			}
			set
			{
				if ((this._Close != value))
				{
					this._Close = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Min", DbType="Decimal(18,2) NOT NULL")]
		public decimal Min
		{
			get
			{
				return this._Min;
			}
			set
			{
				if ((this._Min != value))
				{
					this._Min = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Max", DbType="Decimal(18,2) NOT NULL")]
		public decimal Max
		{
			get
			{
				return this._Max;
			}
			set
			{
				if ((this._Max != value))
				{
					this._Max = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Volume", DbType="BigInt")]
		public System.Nullable<long> Volume
		{
			get
			{
				return this._Volume;
			}
			set
			{
				if ((this._Volume != value))
				{
					this._Volume = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Amount", DbType="BigInt")]
		public System.Nullable<long> Amount
		{
			get
			{
				return this._Amount;
			}
			set
			{
				if ((this._Amount != value))
				{
					this._Amount = value;
				}
			}
		}
	}
	
	public partial class SP_Q1_StockEntityWasUpOrDownByPercentResult
	{
		
		private System.Nullable<int> _year;
		
		private System.Nullable<int> _month;
		
		private System.Nullable<int> _day;
		
		private string _theDate;
		
		public SP_Q1_StockEntityWasUpOrDownByPercentResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_year", DbType="Int")]
		public System.Nullable<int> year
		{
			get
			{
				return this._year;
			}
			set
			{
				if ((this._year != value))
				{
					this._year = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_month", DbType="Int")]
		public System.Nullable<int> month
		{
			get
			{
				return this._month;
			}
			set
			{
				if ((this._month != value))
				{
					this._month = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_day", DbType="Int")]
		public System.Nullable<int> day
		{
			get
			{
				return this._day;
			}
			set
			{
				if ((this._day != value))
				{
					this._day = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_theDate", DbType="NVarChar(33)")]
		public string theDate
		{
			get
			{
				return this._theDate;
			}
			set
			{
				if ((this._theDate != value))
				{
					this._theDate = value;
				}
			}
		}
	}
	
	public partial class SP_Q2_StockEntityGoodAndBadDaysResult
	{
		
		private System.Nullable<int> _Day;
		
		private System.Nullable<int> _NoChange;
		
		private System.Nullable<int> _Positive;
		
		private System.Nullable<int> _Negative;
		
		public SP_Q2_StockEntityGoodAndBadDaysResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Day", DbType="Int")]
		public System.Nullable<int> Day
		{
			get
			{
				return this._Day;
			}
			set
			{
				if ((this._Day != value))
				{
					this._Day = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NoChange", DbType="Int")]
		public System.Nullable<int> NoChange
		{
			get
			{
				return this._NoChange;
			}
			set
			{
				if ((this._NoChange != value))
				{
					this._NoChange = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Positive", DbType="Int")]
		public System.Nullable<int> Positive
		{
			get
			{
				return this._Positive;
			}
			set
			{
				if ((this._Positive != value))
				{
					this._Positive = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Negative", DbType="Int")]
		public System.Nullable<int> Negative
		{
			get
			{
				return this._Negative;
			}
			set
			{
				if ((this._Negative != value))
				{
					this._Negative = value;
				}
			}
		}
	}
	
	public partial class SP_Q3_StockEntityUpDownMonthsResult
	{
		
		private System.Nullable<int> _Year;
		
		private System.Nullable<decimal> @__1;
		
		private System.Nullable<decimal> @__2;
		
		private System.Nullable<decimal> @__3;
		
		private System.Nullable<decimal> @__4;
		
		private System.Nullable<decimal> @__5;
		
		private System.Nullable<decimal> @__6;
		
		private System.Nullable<decimal> @__7;
		
		private System.Nullable<decimal> @__8;
		
		private System.Nullable<decimal> @__9;
		
		private System.Nullable<decimal> @__10;
		
		private System.Nullable<decimal> @__11;
		
		private System.Nullable<decimal> @__12;
		
		public SP_Q3_StockEntityUpDownMonthsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="Int")]
		public System.Nullable<int> Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this._Year = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[1]", Storage="__1", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _1
		{
			get
			{
				return this.@__1;
			}
			set
			{
				if ((this.@__1 != value))
				{
					this.@__1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[2]", Storage="__2", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _2
		{
			get
			{
				return this.@__2;
			}
			set
			{
				if ((this.@__2 != value))
				{
					this.@__2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[3]", Storage="__3", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _3
		{
			get
			{
				return this.@__3;
			}
			set
			{
				if ((this.@__3 != value))
				{
					this.@__3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[4]", Storage="__4", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _4
		{
			get
			{
				return this.@__4;
			}
			set
			{
				if ((this.@__4 != value))
				{
					this.@__4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[5]", Storage="__5", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _5
		{
			get
			{
				return this.@__5;
			}
			set
			{
				if ((this.@__5 != value))
				{
					this.@__5 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[6]", Storage="__6", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _6
		{
			get
			{
				return this.@__6;
			}
			set
			{
				if ((this.@__6 != value))
				{
					this.@__6 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[7]", Storage="__7", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _7
		{
			get
			{
				return this.@__7;
			}
			set
			{
				if ((this.@__7 != value))
				{
					this.@__7 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[8]", Storage="__8", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _8
		{
			get
			{
				return this.@__8;
			}
			set
			{
				if ((this.@__8 != value))
				{
					this.@__8 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[9]", Storage="__9", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _9
		{
			get
			{
				return this.@__9;
			}
			set
			{
				if ((this.@__9 != value))
				{
					this.@__9 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[10]", Storage="__10", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _10
		{
			get
			{
				return this.@__10;
			}
			set
			{
				if ((this.@__10 != value))
				{
					this.@__10 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[11]", Storage="__11", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _11
		{
			get
			{
				return this.@__11;
			}
			set
			{
				if ((this.@__11 != value))
				{
					this.@__11 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[12]", Storage="__12", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _12
		{
			get
			{
				return this.@__12;
			}
			set
			{
				if ((this.@__12 != value))
				{
					this.@__12 = value;
				}
			}
		}
	}
	
	public partial class SP_Q5_StockEntityTypeUpAndDownMonthsResult
	{
		
		private int _StockEntityTypeID;
		
		private int _StockEntityID;
		
		private System.Nullable<int> _Year;
		
		private System.Nullable<decimal> @__1;
		
		private System.Nullable<decimal> @__2;
		
		private System.Nullable<decimal> @__3;
		
		private System.Nullable<decimal> @__4;
		
		private System.Nullable<decimal> @__5;
		
		private System.Nullable<decimal> @__6;
		
		private System.Nullable<decimal> @__7;
		
		private System.Nullable<decimal> @__8;
		
		private System.Nullable<decimal> @__9;
		
		private System.Nullable<decimal> @__10;
		
		private System.Nullable<decimal> @__11;
		
		private System.Nullable<decimal> @__12;
		
		public SP_Q5_StockEntityTypeUpAndDownMonthsResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityTypeID", DbType="Int NOT NULL")]
		public int StockEntityTypeID
		{
			get
			{
				return this._StockEntityTypeID;
			}
			set
			{
				if ((this._StockEntityTypeID != value))
				{
					this._StockEntityTypeID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StockEntityID", DbType="Int NOT NULL")]
		public int StockEntityID
		{
			get
			{
				return this._StockEntityID;
			}
			set
			{
				if ((this._StockEntityID != value))
				{
					this._StockEntityID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Year", DbType="Int")]
		public System.Nullable<int> Year
		{
			get
			{
				return this._Year;
			}
			set
			{
				if ((this._Year != value))
				{
					this._Year = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[1]", Storage="__1", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _1
		{
			get
			{
				return this.@__1;
			}
			set
			{
				if ((this.@__1 != value))
				{
					this.@__1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[2]", Storage="__2", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _2
		{
			get
			{
				return this.@__2;
			}
			set
			{
				if ((this.@__2 != value))
				{
					this.@__2 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[3]", Storage="__3", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _3
		{
			get
			{
				return this.@__3;
			}
			set
			{
				if ((this.@__3 != value))
				{
					this.@__3 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[4]", Storage="__4", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _4
		{
			get
			{
				return this.@__4;
			}
			set
			{
				if ((this.@__4 != value))
				{
					this.@__4 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[5]", Storage="__5", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _5
		{
			get
			{
				return this.@__5;
			}
			set
			{
				if ((this.@__5 != value))
				{
					this.@__5 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[6]", Storage="__6", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _6
		{
			get
			{
				return this.@__6;
			}
			set
			{
				if ((this.@__6 != value))
				{
					this.@__6 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[7]", Storage="__7", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _7
		{
			get
			{
				return this.@__7;
			}
			set
			{
				if ((this.@__7 != value))
				{
					this.@__7 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[8]", Storage="__8", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _8
		{
			get
			{
				return this.@__8;
			}
			set
			{
				if ((this.@__8 != value))
				{
					this.@__8 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[9]", Storage="__9", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _9
		{
			get
			{
				return this.@__9;
			}
			set
			{
				if ((this.@__9 != value))
				{
					this.@__9 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[10]", Storage="__10", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _10
		{
			get
			{
				return this.@__10;
			}
			set
			{
				if ((this.@__10 != value))
				{
					this.@__10 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[11]", Storage="__11", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _11
		{
			get
			{
				return this.@__11;
			}
			set
			{
				if ((this.@__11 != value))
				{
					this.@__11 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[12]", Storage="__12", DbType="Decimal(38,2)")]
		public System.Nullable<decimal> _12
		{
			get
			{
				return this.@__12;
			}
			set
			{
				if ((this.@__12 != value))
				{
					this.@__12 = value;
				}
			}
		}
	}
	
	public partial class SP_Q4_PricesAroundEventDateResult
	{
		
		private System.Nullable<System.DateTime> _ForDate;
		
		private string _DoW;
		
		private System.Nullable<int> _seID;
		
		private int _setID;
		
		private System.Nullable<decimal> _Close;
		
		public SP_Q4_PricesAroundEventDateResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ForDate", DbType="Date")]
		public System.Nullable<System.DateTime> ForDate
		{
			get
			{
				return this._ForDate;
			}
			set
			{
				if ((this._ForDate != value))
				{
					this._ForDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DoW", DbType="NVarChar(30)")]
		public string DoW
		{
			get
			{
				return this._DoW;
			}
			set
			{
				if ((this._DoW != value))
				{
					this._DoW = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_seID", DbType="Int")]
		public System.Nullable<int> seID
		{
			get
			{
				return this._seID;
			}
			set
			{
				if ((this._seID != value))
				{
					this._seID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_setID", DbType="Int NOT NULL")]
		public int setID
		{
			get
			{
				return this._setID;
			}
			set
			{
				if ((this._setID != value))
				{
					this._setID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Close]", Storage="_Close", DbType="Decimal(18,2)")]
		public System.Nullable<decimal> Close
		{
			get
			{
				return this._Close;
			}
			set
			{
				if ((this._Close != value))
				{
					this._Close = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
