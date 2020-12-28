import React from 'react';
import ThreadPreviewList from "./components/ThreadPreviewList";
import Sidebar from "./components/Sidebar";
import Search from "./components/Search";
import NewThread from "./components/NewThread";
import Login from "./components/Login";
import ChangePassword from "./components/ChangePassword";
import UserProfile from "./components/UserProfile";

function App() {
  return (
    <div className="App">
      <div className="container">
        <div class="main-body p-0">
          <div class="inner-wrapper">
            <Search />
            <Sidebar />
            <ThreadPreviewList />
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
