// Amplify Shader Editor - Visual Shader Editing Tool
// Copyright (c) Amplify Creations, Lda <info@amplify.pt>

using UnityEngine;
using System;

namespace AmplifyShaderEditor
{
	[Serializable]
	[NodeAttributes( "Simple Contrast", "Image Effects", "Simple contrast matrix multiplication" )]
	public sealed class SimpleContrastOpNode : ParentNode
	{
		private const string InputTypeStr = "Contrast";
		private const string FunctionHeader = "CalculateContrast({0},{1})";
		private string m_functionBody = string.Empty;
		[SerializeField]
		private float m_defaultContrast = 0;
		protected override void CommonInit( int uniqueId )
		{
			base.CommonInit( uniqueId );
			IOUtils.AddFunctionHeader( ref m_functionBody, "float4 CalculateContrast( float contrastValue, float4 colorTarget )" );
			IOUtils.AddFunctionLine( ref m_functionBody, "float t = 0.5 * ( 1.0 - contrastValue );" );
			IOUtils.AddFunctionLine( ref m_functionBody, "return mul( float4x4( contrastValue, 0, 0, 0,0,contrastValue, 0, 0,0,0,contrastValue, 0,t, t, t, 1 ), colorTarget );" );
			IOUtils.CloseFunctionBody( ref m_functionBody );
			AddPorts();
			m_textLabelWidth = 70;
			m_useInternalPortData = true;
		}

		void AddPorts()
		{
			AddInputPort( WirePortDataType.FLOAT, false, "Value" );
			AddInputPort( WirePortDataType.COLOR, false, "Contrast" );
			AddOutputPort( WirePortDataType.COLOR, Constants.EmptyPortValue );
		}

		public override string GenerateShaderForOutput( int outputId, ref MasterNodeDataCollector dataCollector, bool ignoreLocalVar )
		{
			if ( m_outputPorts[ 0 ].IsLocalValue )
				return m_outputPorts[ 0 ].LocalValue;

			string contrastValue = m_inputPorts[ 0 ].IsConnected ? m_inputPorts[ 0 ].GeneratePortInstructions( ref dataCollector ) : m_defaultContrast.ToString();
			string colorTarget = m_inputPorts[ 1 ].GeneratePortInstructions( ref dataCollector );
			string result = dataCollector.AddFunctions( FunctionHeader, m_functionBody, contrastValue, colorTarget );
			RegisterLocalVariable( 0, result, ref dataCollector, "simpleContrast" + OutputId );

			return m_outputPorts[ 0 ].LocalValue;
		}

		public override void ReadFromString( ref string[] nodeParams )
		{
			base.ReadFromString( ref nodeParams );
			if ( UIUtils.CurrentShaderVersion() < 5004 )
				m_defaultContrast = Convert.ToSingle( GetCurrentParam( ref nodeParams ) );
		}
	}
}
