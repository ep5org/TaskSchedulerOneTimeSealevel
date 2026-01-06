/*******************************************************************************************************************************************************
*    All Project Files Copyright © 2025, 2026 by The ep5 Educational Broadcasting Foundation                                                                 *
*                                                                                                                                                      *
*    Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met:    *
*                                                                                                                                                      *
*        Redistributions of source code must retain the above copyright notice, this list of conditions, and the following disclaimer:                 *
*        Redistributions in binary form must reproduce the above copyright notice, this list of conditions, and the following disclaimer in the        *
*        documentation and/or other materials provided with the distribution.                                                                          *
*        Neither the name of the copyright holder nor the names of its contributors may be used to endorse or promote products derived from this       *
*        software without specific prior written permission.                                                                                           *
*                                                                                                                                                      *
*    THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS “AS IS” AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED     *
*    TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO  EVENT SHALL THE COPYRIGHT HOLDER OR     *
*    CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,         *
*    PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF         *
*    LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT, INCLUDING NEGLIGENCE OR OTHERWISE, ARISING IN ANY WAY OUT OF THE USE OF THIS           *
*    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.                                                                                      *
*******************************************************************************************************************************************************/


USE [TaskSchedulerOneTimeSealevel]
GO

/****** Object:  Table [dbo].[ControlEvent]    Script Date: Monday 24 Mar 2025 7:11:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*DROP TABLE [dbo].[ControlEvent]*/

CREATE TABLE [dbo].[ControlEvent](
	[recordID] [int] IDENTITY(1,1) NOT NULL,
	[recipeID] [int] NOT NULL,
	[channelNmbr] [int] NOT NULL,
	[doAt] [datetime2](2) NOT NULL,
	[whenEntered] [datetime2](2) NOT NULL,
	[whenEdited] [datetime2](2) NOT NULL,
	[enteredBy] [int] NOT NULL,
	[editedBy] [int] NOT NULL,
	[digitalValue] [bit] NOT NULL,
	[notes] [nvarchar](max) NULL,
	[status] [tinyint] NOT NULL,
 CONSTRAINT [PrimaryKeyByRecordID] PRIMARY KEY CLUSTERED 
(
	[recordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'true = ON; false = OFF' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ControlEvent', @level2type=N'COLUMN',@level2name=N'digitalValue'
GO
