//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v13.8.1+dcbbed4
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace SampleUmbracoProject.Models.PageModels
{
	/// <summary>Rich Text Row Settings</summary>
	[PublishedModel("richTextRowSettings")]
	public partial class RichTextRowSettings : PublishedElementModel, IHideProperty, ISpacingProperties
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		public new const string ModelTypeAlias = "richTextRowSettings";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<RichTextRowSettings, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public RichTextRowSettings(IPublishedElement content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Hide: Set this to true if you want to hide this row from the front end of the site
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[ImplementPropertyType("hide")]
		public virtual bool Hide => global::SampleUmbracoProject.Models.PageModels.HideProperty.GetHide(this, _publishedValueFallback);

		///<summary>
		/// Margin Bottom
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("marginBottom")]
		public virtual string MarginBottom => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetMarginBottom(this, _publishedValueFallback);

		///<summary>
		/// Margin Left
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("marginLeft")]
		public virtual string MarginLeft => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetMarginLeft(this, _publishedValueFallback);

		///<summary>
		/// Margin Right
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("marginRight")]
		public virtual string MarginRight => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetMarginRight(this, _publishedValueFallback);

		///<summary>
		/// Margin Top
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("marginTop")]
		public virtual string MarginTop => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetMarginTop(this, _publishedValueFallback);

		///<summary>
		/// Padding Bottom
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("paddingBottom")]
		public virtual string PaddingBottom => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetPaddingBottom(this, _publishedValueFallback);

		///<summary>
		/// Padding Left
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("paddingLeft")]
		public virtual string PaddingLeft => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetPaddingLeft(this, _publishedValueFallback);

		///<summary>
		/// Padding Right
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("paddingRight")]
		public virtual string PaddingRight => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetPaddingRight(this, _publishedValueFallback);

		///<summary>
		/// Padding Top
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.8.1+dcbbed4")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("paddingTop")]
		public virtual string PaddingTop => global::SampleUmbracoProject.Models.PageModels.SpacingProperties.GetPaddingTop(this, _publishedValueFallback);
	}
}
