using Tries;

namespace TestProject;

public class UnitTests
{
    [Fact]
    public void TotalNumberOfWordsInTrie()
    {
            Trie trie = new Trie();
            trie.Insert("a");
            trie.Insert("abc");
            trie.Insert("any");
            trie.Insert("answer");
            trie.Insert("bye");
            trie.Insert("by");
            trie.Insert("the");
            trie.Insert("their");
            trie.Insert("there");

            Assert.Equal(9, trie.TotalNumberOfWords());
    }
}