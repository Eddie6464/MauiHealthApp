using SQLite;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using MentalHealthApp.Models;
using System;

namespace MentalHealthApp.Services
{
    public class DatabaseService
    {
        private SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            // Set the database file path in the app's local storage
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "mentalhealth.db");
            _database = new SQLiteAsyncConnection(databasePath);

            
            _database.CreateTableAsync<EmotionRecord>().Wait();
            _database.CreateTableAsync<ChatMessage>().Wait();
            _database.CreateTableAsync<ActivityLog>().Wait();
            _database.CreateTableAsync<JournalEntry>().Wait(); 
        }

        
        public async Task<int> SaveJournalEntryAsync(JournalEntry entry)
        {
            if (entry.Id == 0)
            {
                return await _database.InsertAsync(entry);
            }
            else
            {
                return await _database.UpdateAsync(entry);
            }
        }

        public async Task<List<JournalEntry>> GetJournalEntriesAsync()
        {
            return await _database.Table<JournalEntry>()
                                 .OrderByDescending(e => e.CreatedDate)
                                 .ToListAsync();
        }

        public async Task<int> ClearChatHistoryAsync()
        {
            return await _database.DeleteAllAsync<ChatMessage>();
        }


        public Task<List<EmotionRecord>> GetEmotionRecordsAsync() =>
            _database.Table<EmotionRecord>().OrderByDescending(r => r.Date).ToListAsync();

        public Task<int> SaveEmotionRecordAsync(EmotionRecord record) =>
            record.Id == 0 ? _database.InsertAsync(record) : _database.UpdateAsync(record);

       
        public Task<List<ChatMessage>> GetChatHistoryAsync() =>
            _database.Table<ChatMessage>().OrderByDescending(m => m.Timestamp).ToListAsync();

        public Task<int> SaveChatMessageAsync(ChatMessage message) =>
            _database.InsertAsync(message);

        
        public Task<List<ActivityLog>> GetActivityLogsAsync() =>
            _database.Table<ActivityLog>().OrderByDescending(a => a.StartTime).ToListAsync();

        public Task<int> StartActivityAsync(ActivityLog log) =>
            _database.InsertAsync(log);

        public Task<int> EndActivityAsync(ActivityLog log)
        {
            log.EndTime = DateTime.Now;
            return _database.UpdateAsync(log);
        }

        public Task<int> DeleteEmotionRecordAsync(EmotionRecord record) =>
              _database.DeleteAsync(record);

        public Task<int> DeleteJournalEntryAsync(JournalEntry entry)
        {
            return _database.DeleteAsync(entry);
        }


    }
}
