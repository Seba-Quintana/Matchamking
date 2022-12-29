import React from 'react'
import HeaderText from '../Atoms/HeaderText'
import styled from 'styled-components'
import crown from '../../assets/bxs-crown.svg'

const TitleContainer = styled.div`
    display: flex;

`

const TitleHeader = () => {
  return (
    <TitleContainer>
        <HeaderText text={'MatchamKing'}></HeaderText>
        <img src={crown}></img>
    </TitleContainer>
  )
}

export default TitleHeader