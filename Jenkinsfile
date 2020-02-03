def label = "jenkins-slave-${UUID.randomUUID().toString()}"

podTemplate(
    name: label,
    label: label, 
    containers: [
        containerTemplate(name: 'jnlp', image: 'registry.check.com/netcore/jnlp-slave:3.40')
    ], 
    volumes: [
    hostPathVolume(mountPath: '/root/.kube', hostPath: '/root/.kube'),
    hostPathVolume(mountPath: '/var/run/docker.sock', hostPath: '/var/run/docker.sock')
    ]) 
{
    node(label) {
        def myRepo = checkout scm
        def gitCommit = myRepo.GIT_COMMIT
        def gitBranch = myRepo.GIT_BRANCH
        def imageTag = sh(script: "git rev-parse --short HEAD", returnStdout: true).trim()
        def dockerRegistryUrl = "registry.check.com"
        def imageEndpoint = "netcore/name-api"
        def image = "${dockerRegistryUrl}/${imageEndpoint}"
        stage('单元测试') {
            echo "1.测试阶段"
        }
        stage('构建 Docker 镜像') {
            try{
                withCredentials([[$class: 'UsernamePasswordMultiBinding',
                credentialsId: 'harborAuth',
                usernameVariable: 'DOCKER_HUB_USER',
                passwordVariable: 'DOCKER_HUB_PASSWORD']]) {
                container('jnlp') {
                    echo "2. 构建 Docker 镜像阶段"
                    sh """
                    docker login ${dockerRegistryUrl} -u ${DOCKER_HUB_USER} -p ${DOCKER_HUB_PASSWORD}
                    docker build -t ${image}:${imageTag} .
                    docker push ${image}:${imageTag}
                    """
                }
                }
            }
            catch(exc) {
                println "构建镜像失败 - ${currentBuild.fullDisplayName}"
                throw(exc)
            }
            
        }
        stage('发布上线') {
            container('jnlp') {
                echo "3. 发布上线"
                if (env.BRANCH_NAME == 'master') {
                    input "确认要部署线上环境吗？"
                }
                sh "sed -i 's/<BUILD_TAG>/${imageTag}/' deployNameApi.yaml"
                sh "kubectl apply -f deployNameApi.yaml --record"
            }
        }
    }
}