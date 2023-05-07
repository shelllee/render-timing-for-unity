set JAVA_HOME=D:\Program_Files\Unity\Hub\Editor\2019.4.38f1\Editor\Data\PlaybackEngines\AndroidPlayer\OpenJDK
set PATH=%JAVA_HOME%\bin;%JAVA_HOME%\jre\bin;%PATH%
set CLASSPATH=.;%JAVA_HOME%\lib\dt.jar;%JAVA_HOME%\lib\tools.jar
set ANDROID_HOME=D:\Program_Files\Unity\Hub\Editor\2019.4.38f1\Editor\Data\PlaybackEngines\AndroidPlayer\SDK
set PATH=%ANDROID_HOME%\tools\bin;%PATH%
set ANDROID_NDK_HOME=D:\Program_Files\Unity\Hub\Editor\2019.4.38f1\Editor\Data\PlaybackEngines\AndroidPlayer\NDK
set PATH=%ANDROID_NDK_HOME%;%PATH%

start gradlew build
