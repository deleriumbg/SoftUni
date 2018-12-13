using System.Linq;

namespace FestivalManager.Entities
{
	using System.Collections.Generic;
	using Contracts;

	public class Stage : IStage
	{
		private readonly List<ISet> sets;
		private readonly List<ISong> songs;
		private readonly List<IPerformer> performers;

	    public Stage()
	    {
	        this.sets = new List<ISet>();
	        this.songs = new List<ISong>();
	        this.performers = new List<IPerformer>();
	    }

	    public IReadOnlyCollection<ISet> Sets => this.sets.AsReadOnly();
	    public IReadOnlyCollection<ISong> Songs => this.songs.AsReadOnly();
	    public IReadOnlyCollection<IPerformer> Performers => this.performers.AsReadOnly();

	    public IPerformer GetPerformer(string name) => this.Performers.FirstOrDefault(p => p.Name == name);

	    public ISong GetSong(string name) => this.Songs.FirstOrDefault(s => s.Name == name);

	    public ISet GetSet(string name) => this.Sets.FirstOrDefault(s => s.Name == name);

	    public void AddPerformer(IPerformer performer) => this.performers.Add(performer);

	    public void AddSong(ISong song) => this.songs.Add(song);

	    public void AddSet(ISet set) => this.sets.Add(set);

	    public bool HasPerformer(string name) => this.Performers.Any(p => p.Name == name);

	    public bool HasSong(string name) => this.Songs.Any(s => s.Name == name);

	    public bool HasSet(string name) => this.Sets.Any(s => s.Name == name);
	}
}
