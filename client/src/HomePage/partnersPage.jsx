import * as React from 'react';
import styles from "./style/dashboard.module.css"
import bar from "../assets/Bar Chart Border Radius.svg"
import TaskesBar from '../componenet/taskesBar'
import SearchBar from '../componenet/searchBar'
import notification from "../assets/Bell_pin.svg"
import Profilecard from "../componenet/profilecard"
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DateField } from '@mui/x-date-pickers/DateField';
import off from "../assets/off.svg"
import ButtonWithIcons from "../componenet/buttonWithIcons"
import time from "../assets/Leading Icon.svg"
import done from "../assets/Leading Icon2.svg"
import error from "../assets/Leading Icon3.png"
import EmployeInformation from "../componenet/employeInformation.jsx"
import photo from "../assets/female.svg"
import logo from "../assets/campanylogo.svg"
import photo1 from "../assets/10.png"
import  uc from "../assets/uc.svg"
import logoo from "../assets/Primery LOGO2.svg"
import allthelogo from "../assets/allthelogo.svg"
import IaCard from "../componenet/iaCard.jsx"
import style from "./style/partnersPage.module.css"
const partnersPage = ({clicked}) => {
  return (
    <div className={`${styles.hero} ${clicked ? styles.not_display: ''}`}>
      
      <section className={styles.firstCountainer}>
        <img src={logoo} className={styles.logooImage}></img>
        <div className={style.barCountainer}>
          <img src={bar}></img>
          <TaskesBar taskStatus={"Task Queue"} taskTache={154}/>
          <TaskesBar taskStatus={"Finiched Tasks"} taskTache={254}/>
          <TaskesBar taskStatus={"Task Request"} taskTache={94}/>
        </div>
      </section>  
      <section className={styles.mainCountainer}>
         <nav className={styles.Header}>
            <section className={styles.searchANDprofile}>
              <SearchBar></SearchBar>
               <mark className={styles.profileNotificationAndAccess}>
                   <img src={notification}></img>
                   <img src={allthelogo}/>
               </mark>
            </section>
            </nav>
            </section>
            </div>
  )
}

export default partnersPage
