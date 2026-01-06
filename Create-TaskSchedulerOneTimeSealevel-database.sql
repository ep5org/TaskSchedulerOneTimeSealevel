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

USE [master]
GO

/****** Object:  Database [TaskSchedulerOneTimeSealevel]    Script Date: Wednesday, 26 July, 2023 02:30:28 PM ******/
CREATE DATABASE [TaskSchedulerOneTimeSealevel]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TaskSchedulerOneTimeSealevel', FILENAME = N'Z:\data\TaskSchedulerOneTimeSealevel.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TaskSchedulerOneTimeSealevel_log', FILENAME = N'Z:\data\TaskSchedulerOneTimeSealevel_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TaskSchedulerOneTimeSealevel].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ARITHABORT OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET  DISABLE_BROKER 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET  MULTI_USER 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET DB_CHAINING OFF 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET QUERY_STORE = OFF
GO

ALTER DATABASE [TaskSchedulerOneTimeSealevel] SET  READ_WRITE 
GO

