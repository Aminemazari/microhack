import React from 'react'
import searchIcon from "../assets/searchIcon.svg"
import style from "./style.module.css"
const searchBar = ({onchange,inputValue}) => {
  return (
    <div className={style.searchBarCountainer}> 
     <img src={searchIcon} className={style.searchIcon}></img>
     <input className={style.searchBar} 
      onChange={onchange}
      value={inputValue}
      placeholder='Hinted search text'
    >
      
    </input>
    </div>

  )
}

export default searchBar
