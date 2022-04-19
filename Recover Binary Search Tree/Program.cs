namespace Recover_Binary_Search_Tree
{

  // https://leetcode.com/problems/recover-binary-search-tree/discuss/1466747/C-or-Super-Simple-and-Clean
  /// 2 Nodes of a BST are swapped by mistake. Recover the BST by reverse swapping those swapped nodes.
  /// Solution: Since BST Inorder traversal gives elements in increasing order, we can traverse bst in inorder and look
  /// for nodes which violates the increasing order.
  /// We just have to find and swap the violating keys
  ///
  /// There can be 2 cases.
  /// Case 1: When adjucent nodes are swapped i.e. eg: 1,2,4,3,5,6
  /// In this case we get only one violation (3) and that and it's previous (4) needed to be swapped.
  /// i.e. swap 4 and 3 and we get 1,2,3,4,5,6
  ///
  /// Case 2: When non adjucent nodes are swapped i.e. eg: 1,6,3,4,5,2 {6 and 2 are swapped}
  /// Then first violation's = 3
  /// 2nd violation = 2
  /// Swap previous of first violation with 2nd violation
  /// and we get 1,2,3,4,5,6
  class Program
  {
    static void Main(string[] args)
    {
      TreeNode root = new TreeNode(4);
      root.left = new TreeNode(6);
      root.left.left = new TreeNode(1);
      root.left.right = new TreeNode(3);

      root.right = new TreeNode(5);
      root.right.right = new TreeNode(2);
      Program p = new Program();
      p.RecoverTree(root);

    }

    public class TreeNode
    {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
      {
        this.val = val;
        this.left = left;
        this.right = right;
      }
    }
    private TreeNode first;
    private TreeNode second;
    private TreeNode prev;
    public void RecoverTree(TreeNode root)
    {
      if (root == null) return;
      first = null;
      second = null;
      prev = null;
      inorder(root);

      int temp = first.val;
      first.val = second.val;
      second.val = temp;
    }

    private void inorder(TreeNode root)
    {
      if (root == null) return;
      inorder(root.left);
      // business logic
      if(prev != null && root.val < prev.val)
      {
        if (first == null) first = prev;
        second = root;
      }

      prev = root;
      inorder(root.right);
    }
  }
}
