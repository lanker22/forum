import React, { useContext, useState } from "react";
import moment from "moment";
import UserContext from "./UserContext";

var Post = (props) => {
  var [user, setUser] = useContext(UserContext);
  const [postData, setPostData] = useState(props.post);

  var timePosted = moment
    .utc(props.post.timePosted)
    .format("dddd, MMMM Do, h:mm a");

  const [hasUserLikedPost, setHasUserLikedPost] = useState(() => {
    postData.likes.forEach((item) => {
      console.log(item);
      if (item.applicationUser.userName === user) {
        return true;
      }
    });
    return false;
  });

  var likePost = async () => {
    try {
      const response = await fetch(
        `http://localhost:5000/api/post/like/${props.post.postId}`,
        {
          credentials: "include",
          headers: {
            "Content-Type": "application/json",
          },
        }
      );
      const data = await response.json();
      console.log(data);
      setPostData(data);
    } catch (err) {
      console.log(err);
    }
  };

  return (
    <div className="card mb-2">
      <div className="card-body">
        <div className="media forum-item">
          <a href="" className="card-link">
            <img
              src="https://bootdey.com/img/Content/avatar/avatar1.png"
              className="rounded-circle"
              width="50"
              alt="User"
            />
          </a>
          <div className="media-body ml-3">
            <span className="text-secondary">
              {postData.applicationUser.userName}
            </span>
            <div className="mt-3 font-size-sm">
              <p>{postData.content}</p>
              <small className="text-muted">{timePosted}</small>
            </div>
          </div>
          <div className="text-muted small text-center">
            <span className="d-none d-sm-inline-block">
              <i className="far fa-eye"></i> {postData.likes.length}
            </span>
          </div>
        </div>
        {user === "" ? (
          ""
        ) : hasUserLikedPost ? (
          <small>Liked</small>
        ) : (
          <button className="btn btn-primary" onClick={likePost}>
            Like
          </button>
        )}
      </div>
    </div>
  );
};

export default Post;
