namespace CursoResidencia.Domain.Models
{
    public class AlunoPodcast
    {
        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
        public DateTime Data { get; set; }
    }
}
