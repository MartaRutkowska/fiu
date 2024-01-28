namespace Tries
{
    public class Node
    {
        const int ALPHABET_SIZE = 26;
        public Node[] children = new Node[ALPHABET_SIZE];
        public bool isEndLetter {get; set;}
    }

    public class Trie
    {
        Node root = new();

        public static int GetIndex(char c){
            return c - 'a';
        }

        public void Insert(string word)
        {

            if(word == string.Empty) return;
            
            var currentNode = root;

            for(int i=0; i<word.Length; i++)
            {
                var index = GetIndex(word[i]);

                if(currentNode.children[index] == null)
                {
                    currentNode.children[index] = new Node();
                }
                currentNode = currentNode.children[index];
            }

            currentNode.isEndLetter = true;
        }

        public bool Search(string word)
        {
            var currentNode = root;

            for(int i=0; i<word.Length; i++)
            {
                var index = GetIndex(word[i]);

                if(currentNode.children[index] != null){
                    currentNode = currentNode.children[index];
                }
                else return false;
            }

            if(currentNode.isEndLetter && currentNode != null){
                return true;
            }

            return false;

        }

        public int TotalNumberOfWords()
        {
            var counter = 0;
            var currentNode = root;

            counter += GoDeeper(currentNode, counter);
            return counter;
        }

        public static int GoDeeper(Node node, int counter)
        {

            if(node == null) return counter;

            if(node.isEndLetter == true){
                counter++;
            }

            for(int i = 0; i <node.children.Length; i++ ){
                if(node.children[i] != null){
                    counter = GoDeeper(node.children[i], counter);
                }
            }

            return counter;
        }
    }
}