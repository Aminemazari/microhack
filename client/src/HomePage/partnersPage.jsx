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
import Partnerform from '../componenet/partnerform.jsx';
import campany1 from "../assets/campany1.svg"
import campany2 from "../assets/campany2.svg"
import campany3 from "../assets/campany3.svg"
import campany4 from "../assets/campany4.svg"
import campany5 from "../assets/campany5.svg"

const partnersPage = ({cliked}) => {
  return (
    <div className={`${styles.hero} ${!cliked ? styles.not_display: ''}`}>
      
      <section className={styles.firstCountainer}>
        <img src={logoo} className={styles.logooImage}></img>
        <div className={styles.barCountainer}>
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
        <section className={style.listPartners}>
                <div className={style.form}>
                    <p className={style.company}>Company</p>
                    <p className={style.company}>Details</p>
                </div>
                <section className={style.data}>
                  <Partnerform campanyImage={logo} nameCompany={"Bolt & Gear"} service={"Industrial Services"} ></Partnerform>
                  <Partnerform campanyImage={campany1} nameCompany={"Bolt & Gear"} service={"Production"} ></Partnerform>
                  <Partnerform campanyImage={campany2} nameCompany={"Bolt & Gear"} service={""} ></Partnerform>
                  <Partnerform campanyImage={campany3} nameCompany={"Bolt & Gear"} service={"Information T."} ></Partnerform>
                  <Partnerform campanyImage={campany4} nameCompany={"Bolt & Gear"} service={"Energy"} ></Partnerform>
                  <Partnerform campanyImage={campany5} nameCompany={"Bolt & Gear"} service={"Consumer Goods"} ></Partnerform>
                 
    

                </section>
            </section>
            </section>

            </div>
  )
}

export default partnersPage
