import React from 'react';
import Sidebar from "./Sidebar";
import Search from "./Search";
import ThreadPreviewList from "./ThreadPreviewList";

var Home = () => {
    return (
        <div className="container">
        <div class="main-body p-0">
          <div class="inner-wrapper">
            <Sidebar />
            <div className="inner-main">
              <Search />
              <ThreadPreviewList />
            </div>
          </div>
        </div>
      </div>
    )
}

export default Home;