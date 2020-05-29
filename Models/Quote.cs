namespace Solution
{
    public class Quote
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Заполните текст цитаты!")]
        public string Text { get; set; }
        public string Author { get; set; }
        [Required(ErrorMessage = "Введите дату!")]
        public System.DateTime InsertDate { get; set; }
    }
}