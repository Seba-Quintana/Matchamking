import React from 'react'
import BackArrow from '../Components/Atoms/BackArrow'
import MatchFinder from '../Components/Molecules/MatchFinder'
import ResultsContainer from '../Components/Atoms/ResultsContainer'
import HeaderText from '../Components/Atoms/HeaderText'


const MatchHistory = () => {
  return (
    <>
          <BackArrow navigate={'/'}></BackArrow>
          <HeaderText text='Explorar partidos'></HeaderText>
          <MatchFinder></MatchFinder>
          <ResultsContainer></ResultsContainer>
    </>
  )
}

export default MatchHistory