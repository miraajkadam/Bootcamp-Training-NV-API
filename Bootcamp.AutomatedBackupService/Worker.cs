﻿using Bootcamp.AutomatedBackupService.Interfaces;
using Bootcamp.Data.Interfaces;
using Bootcamp.Data.Models;
using System.Text;

namespace Bootcamp.AutomatedBackupService
{
    public class Worker : IWorker
    {
        private readonly IEngagementRepository _engagementRepository;
        private ICustomPeriodicTimer _timer;

        public Worker(IEngagementRepository engagementRepository, ICustomPeriodicTimer timer)
        {
            _engagementRepository = engagementRepository;
            _timer = timer;
        }

        public async Task BackupEngagements()
        {
            using (_timer)
            {
                while (await _timer.WaitForNextTickAsync())
                {
                    Console.WriteLine($"Code executed at: {DateTime.Now}");

                    try
                    {
                        var engagements = await _engagementRepository.GetAllEngagements();

                        var guid = Guid.NewGuid();

                        foreach (var engagement in engagements)
                        {
                            var existingEntity = _engagementRepository.GetEngagementBackupById(engagement.EngagementId);

                            if (existingEntity != null)
                            {
                                Console.WriteLine($"Already Exists..., Id - {engagement.EngagementId}");

                                existingEntity.Auditors = engagement.Auditors;
                                existingEntity.AuditTypeId = (int)engagement.AuditTypeId;
                                existingEntity.ClientName = engagement.ClientName;
                                existingEntity.CountryId = engagement.CountryId;
                                existingEntity.AuditEndDate = engagement.AuditEndDate;
                                existingEntity.AuditStartDate = engagement.AuditStartDate;
                                existingEntity.BackupId = guid.ToString();
                                existingEntity.BackupTimestamp = DateTime.Now;

                                _engagementRepository.PerformEngagementBackup(existingEntity, true);
                            }
                            else
                            {
                                Console.WriteLine($"Creating New..., Id - {engagement.EngagementId}");

                                var engagementBackup = new EngagementBackup()
                                {
                                    Auditors = engagement.Auditors,
                                    AuditTypeId = (int)engagement.AuditTypeId,
                                    ClientName = engagement.ClientName,
                                    CountryId = engagement.CountryId,
                                    AuditEndDate = engagement.AuditEndDate,
                                    AuditStartDate = engagement.AuditStartDate,
                                    BackupId = guid.ToString(),
                                    BackupTimestamp = DateTime.Now,
                                    EngagementId = engagement.EngagementId
                                };

                                _engagementRepository.PerformEngagementBackup(engagementBackup, false);
                            }
                        }


                        LogSuccess();
                    }
                    catch (Exception ex)
                    {
                        LogError(ex.ToString());
                    }
                }
            }
        }

        static void LogSuccess()
        {
            StringBuilder sb = new();

            sb.Append($"Backup created successfully at - {DateTime.Now}");
            sb.Append("\n\n");


            File.AppendAllText("log.txt", sb.ToString());

            sb.Clear();
        }

        static void LogError(string exception)
        {
            StringBuilder sb = new();

            sb.Append($"Backup created failed at - {DateTime.Now}");
            sb.Append("\n");
            sb.Append($"Exception - {exception}");
            sb.Append("\n\n");

            File.AppendAllText("log.txt", sb.ToString());

            sb.Clear();
        }

    }
}
