import React, { useState } from "react";
import Sidebar from "./Sidebar";
import Search from "./Search";
import Thread from "./Thread";
import ThreadPreviewList from "./ThreadPreviewList";
import NewThread from "./NewThread";
import { Switch, Route, BrowserRouter } from "react-router-dom";

var Home = () => {
  const [threadSortOption, setThreadSortOption] = useState("recent");

  console.log("home");

  return (
    <div className="container">
      <div className="main-body p-0">
        <div className="inner-wrapper">
          <Sidebar />
          <div className="inner-main">
            <Search
              option={{
                threadSortOption: threadSortOption,
                setThreadSortOption: setThreadSortOption,
              }}
            />
            <BrowserRouter>
              <Switch>
                <Route
                  exact
                  path="/"
                  render={(props) => (
                    <ThreadPreviewList
                      {...props}
                      threadSortOption={threadSortOption}
                    />
                  )}
                />
                <Route path="/thread/:id" component={Thread} />
              </Switch>
            </BrowserRouter>
          </div>
        </div>
      </div>
      <NewThread />
    </div>
  );
};

export default Home;
