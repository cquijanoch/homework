setwd("D:/testingScatterplot/scatterplotTraining/Assets/Assets/Resources")
data1.origin <- read.csv("fixing_dataset.csv",header=T) 
data1.data <- data1.origin[,1:7]
attach(data1.data)
arthot <- data1.data[,1]
sonhot <- data1.data[,2]
duration <- data1.data[,3]
key <- data1.data[,4]
loudness <- data1.data[,5]
tempo <- data1.data[,6]
terms <- data1.data[,7]
data1.data$artist.hotttnesss <- (arthot - mean(arthot)) / sd(arthot)
data1.data$song.hotttnesss <- (sonhot - mean(sonhot)) / sd(sonhot)
data1.data$duration <- (duration - mean(duration)) / sd(duration)
data1.data$key <- (key- mean(key)) / sd(key)
data1.data$loudness <- (loudness - mean(loudness)) / sd(loudness)
data1.data$tempo <- (tempo - mean(tempo)) / sd(tempo)
data1.pca <- prcomp(data1.data[1:6],scale=T)
data1.pcax <- data1.pca$x
data1.pcax <- cbind(data1.pcax,term="a")


write.csv(data1.pcax, file = "MyData.csv")





data1.pca <- prcomp(data1.data[,-7],scale = T)


fviz_pca_ind(data1.pca,
             geom.ind = "point", # show points only (nbut not "text")
             col.ind = data1.data$terms, # color by groups
                          addEllipses = TRUE, # Concentration ellipses
             legend.title = "Groups"
             )