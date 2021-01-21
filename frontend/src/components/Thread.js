import React, { useEffect, useState, useContext } from "react";
import { useParams, useHistory } from "react-router-dom";
import Post from "./Post";
import Loading from "./Loading";
import UserContext from "./UserContext";

const Thread = () => {
  const { id } = useParams();
  const [user, setUser] = useContext(UserContext);
  const [thread, setThread] = useState(null);
  const history = useHistory();
  const [newPostContent, setNewPostContent] = useState("");

  console.log(thread);

  const fetchThread = async () => {
    const response = await fetch(`http://localhost:5000/api/thread/${id}`, {
      credentials: "include",
      headers: {
        "Content-Type": "application/json",
      },
    });
    try {
      const data = await response.json();
      setThread(data);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    fetchThread();
  }, []);

  const handleNewPostSubmit = async (e) => {
    e.preventDefault();
    if (user === "") {
      history.replace("/login");
      history.go(0);
    } else {
      try {
        console.log(thread.threadId);
        const response = await fetch("http://localhost:5000/api/post/create", {
          credentials: "include",
          method: "POST",
          headers: {
            "Content-Type": "application/json",
          },
          body: JSON.stringify({
            Content: newPostContent,
            TimePosted: new Date().toISOString(),
            ThreadId: thread.threadId,
          }),
        });
        let data = await response.json();
        setThread(data);
        setNewPostContent("");
      } catch (err) {
        console.log(err);
      }
    }
  };

  return (
    <div className="inner-main-body p-2 p-sm-3 collapse forum-content show">
      {thread ? <h3 style={{ paddingBottom: "10px" }}>{thread.title}</h3> : ""}
      {thread ? (
        thread.posts.map((post) => <Post key={post.postId} post={post} />)
      ) : (
        <Loading />
      )}
      <form onSubmit={handleNewPostSubmit}>
        <div className="form-group shadow-textarea">
          <textarea
            value={newPostContent}
            onChange={(e) => setNewPostContent(e.target.value)}
            className="form-control z-depth-1"
            id="exampleFormControlTextarea6"
            rows="3"
            placeholder="New post"
          ></textarea>
        </div>
        <button className="btn btn-primary" type="submit">
          Post
        </button>
      </form>
    </div>
  );
};

export default Thread;
