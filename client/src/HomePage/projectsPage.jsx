import * as React from 'react';
import style from "./style/projectsPage.module.css"
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
const projectsPage = ({cliked}) => {
  return (
    <div className={`${style.hero} ${!cliked ? style.not_display: ''}`}>
         <section className={styles.firstCountainer}>
        <img src={logoo} className={styles.logooImage}></img>
        <div className={styles.barCountainer}>
          <img src={bar}></img>
          <TaskesBar taskStatus={"Task Queue"} taskTache={123}/>
          <TaskesBar taskStatus={"Finiched Tasks"} taskTache={54}/>
          <TaskesBar taskStatus={"Task Request"} taskTache={123}/>
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
            <section className={style.filterHeader}>
            <button className={style.statusButtonStart}>Done</button>
            <button className={style.statusbutton}>Pending</button>
            <button className={style.statusbutton}>In Progress</button>
            <button className={style.statusbutton}>Canceled</button>
            <button className={style.statusbuttonEnd}>Discard</button>


         </section>
         </nav>
         <p className={style.projects}>Projects</p>
         <section className={style.projectsList}>
        <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"pending"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"inprogress"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"done"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"discard"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"pending"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"inprogress"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"done"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"discard"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"pending"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"inprogress"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"done"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"discard"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"pending"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"inprogress"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"done"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"discard"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"pending"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"inprogress"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"done"}/>
     <IaCard projectTitle={"Project title"} campanyName={"Company name"} campanyPics={logo}   title={"lOREM ISPUM DOLLOR SIT"} status={"discard"}/>
         </section>
         </section>
    </div>
  )
}

export default projectsPage
