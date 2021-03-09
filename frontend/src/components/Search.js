import React from "react";

var Search = (props) => {
  console.log(props);

  const handleSelect = (e) => {
    props.option.setThreadSortOption(e.target.value);
  };

  return (
    <div className="inner-main-header">
      <a
        className="nav-link nav-icon rounded-circle nav-link-faded mr-3 d-md-none"
        href=""
        data-toggle="inner-sidebar"
      >
        <i className="material-icons">arrow_forward_ios</i>
      </a>
      <select
        value={props.option.threadSortOption}
        onChange={handleSelect}
        className="custom-select custom-select-sm w-auto mr-1"
      >
        <option value="recent">Latest</option>
        <option value="popular">Popular</option>
        <option value="noreplies">No Replies Yet</option>
      </select>
    </div>
  );
};

export default Search;
