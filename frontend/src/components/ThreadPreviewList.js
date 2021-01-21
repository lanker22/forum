import React, { useEffect, useState } from "react";
import ThreadPreview from "./ThreadPreview";
import Loading from "./Loading";

var ThreadPreviewList = (props) => {
  const [threads, setThreads] = useState({});

  const fetchThreads = async () => {
    const response = await fetch(
      `http://localhost:5000/api/thread/${props.threadSortOption}`,
      {
        credentials: "include",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );
    try {
      const data = await response.json();
      setThreads(data);
    } catch (err) {
      console.log(err);
    }
  };

  useEffect(() => {
    fetchThreads();
  }, [props.threadSortOption]);

  return (
    <div className="inner-main-body p-2 p-sm-3 collapse forum-content show">
      {threads.length > 0 ? (
        threads.map((thread) => (
          <ThreadPreview key={thread.threadId} thread={thread} />
        ))
      ) : (
        <Loading />
      )}
    </div>
  );
};

export default ThreadPreviewList;
