<TestFixture()> _
Public Class Basics

  <Test()> _
  Public Sub CreateRoot()
    Session.Clear()
    Dim root As root
    root = root.NewRoot
    Assert.IsNotNull(root)
    Assert.AreEqual("<new>", root.Data)
    Assert.AreEqual("Created", Session("Root"))
    Assert.AreEqual(True, root.IsNew)
    Assert.AreEqual(False, root.IsDeleted)
    Assert.AreEqual(True, root.IsDirty)
  End Sub

  <Test()> _
  Public Sub AddChild()
    Session.Clear()
    Dim root As root = root.NewRoot
    root.Children.Add("1")
    Assert.AreEqual(1, root.Children.Count)
    Assert.AreEqual("1", root.Children(0).Data)
  End Sub

  <Test()> _
  Public Sub AddRemoveChild()
    Session.Clear()
    Dim root As root = root.NewRoot
    root.Children.Add("1")
    root.Children.Remove(root.Children.Item(0))
    Assert.AreEqual(0, root.Children.Count)
  End Sub

  <Test()> _
  Public Sub AddGrandChild()
    Session.Clear()
    Dim root As root = root.NewRoot
    root.Children.Add("1")
    Dim child As child = root.Children(0)
    child.GrandChildren.Add("1")
    Assert.AreEqual(1, child.GrandChildren.Count)
    Assert.AreEqual("1", child.GrandChildren(0).Data)
  End Sub

  <Test()> _
  Public Sub AddRemoveGrandChild()
    Session.Clear()
    Dim root As root = root.NewRoot
    root.Children.Add("1")
    Dim child As child = root.Children(0)
    child.GrandChildren.Add("1")
    child.GrandChildren.Remove(child.GrandChildren.Item(0))
    Assert.AreEqual(0, child.GrandChildren.Count)
  End Sub

  <Test()> _
  Public Sub CloneGraph()
    Session.Clear()
    Dim root As root = root.NewRoot
    root.Children.Add("1")
    Dim child As child = root.Children(0)
    child.GrandChildren.Add("1")
    Assert.AreEqual(1, child.GrandChildren.Count)
    Assert.AreEqual("1", child.GrandChildren(0).Data)

    Dim clone As root = DirectCast(root.Clone, root)
    child = clone.Children(0)
    Assert.AreEqual(1, child.GrandChildren.Count)
    Assert.AreEqual("1", child.GrandChildren(0).Data)

  End Sub

End Class
