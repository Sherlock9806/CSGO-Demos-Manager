﻿using CSGO_Demos_Manager.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using CSGO_Demos_Manager.Models.Charts;
using CSGO_Demos_Manager.Models.Stats;

namespace CSGO_Demos_Manager.Services.Interfaces
{
	public interface IDemosService
	{
		/// <summary>
		/// Return only demos header
		/// </summary>
		/// <param name="folders"></param>
		/// <param name="currentDemos"></param>
		/// <param name="limit"></param>
		/// <returns></returns>
		Task<List<Demo>> GetDemosHeader(List<string> folders, List<Demo> currentDemos = null, bool limit = false);

		/// <summary>
		/// Return the whole demo
		/// </summary>
		/// <param name="demo"></param>
		/// <returns></returns>
		Task<Demo> GetDemoDataAsync(Demo demo);

		/// <summary>
		/// Analyze the demo passed on parameter
		/// </summary>
		/// <param name="demo"></param>
		/// <returns></returns>
		Task<Demo> AnalyzeDemo(Demo demo, CancellationToken token);

		/// <summary>
		/// Save the demo's comment
		/// </summary>
		/// <param name="demo"></param>
		/// <param name="comment"></param>
		/// <returns></returns>
		Task SaveComment(Demo demo, string comment);

		/// <summary>
		/// Save the demo's status
		/// </summary>
		/// <param name="demo"></param>
		/// <param name="status"></param>
		/// <returns></returns>
		Task SaveStatus(Demo demo, string status);

		Task SetSource(ObservableCollection<Demo> demos, string source);

		Task<Demo> AnalyzePlayersPosition(Demo demo, CancellationToken token);

		Task<List<Demo>> GetDemosFromBackup(string jsonFile);

		Task<Demo> AnalyzeBannedPlayersAsync(Demo demo);

		/// <summary>
		/// Return the last rank detected for the specific steamId
		/// </summary>
		/// <param name="steamId"></param>
		/// <returns></returns>
		Task<Rank> GetLastRankAccountStatsAsync(long steamId);

		/// <summary>
		/// Return Rank model evolution for the rank chart
		/// </summary>
		/// <returns></returns>
		Task<List<RankDateChart>> GetRankDateChartDataAsync();

		/// <summary>
		/// Return overall stats for the selected account
		/// </summary>
		/// <returns></returns>
		Task<OverallStats> GetGeneralAccountStatsAsync();

		/// <summary>
		/// Return stats for the map stats view
		/// </summary>
		/// <returns></returns>
		Task<MapStats> GetMapStatsAsync();

		/// <summary>
		/// Return stats for the weapon stats view
		/// </summary>
		/// <returns></returns>
		Task<WeaponStats> GetWeaponStatsAsync();

		/// <summary>
		/// Return demos that contains the SteamID
		/// </summary>
		/// <param name="steamId"></param>
		/// <returns></returns>
		Task<List<Demo>> GetDemosPlayer(string steamId);

		/// <summary>
		/// Return stats for the progression stats view
		/// </summary>
		/// <returns></returns>
		Task<ProgressStats> GetProgressStatsAsync();

		/// <summary>
		/// Delete a demo from file system
		/// </summary>
		/// <param name="demo"></param>
		/// <returns></returns>
		Task<bool> DeleteDemo(Demo demo);

		/// <summary>
		/// Return the list of demos that need to be downloaded
		/// demo name => demo URL 
		/// </summary>
		/// <returns></returns>
		Task<Dictionary<string, string>> GetDemoListUrl();

		/// <summary>
		/// Download the demo archive
		/// </summary>
		/// <param name="url">Url of the demo archive</param>
		/// <param name="location">Location where the archive will be saved</param>
		/// <returns></returns>
		Task<bool> DownloadDemo(string url, string location);

		/// <summary>
		/// Decompress the demo archive
		/// </summary>
		/// <param name="demoName"></param>
		/// <returns></returns>
		Task<bool> DecompressDemoArchive(string demoName);
	}
}
